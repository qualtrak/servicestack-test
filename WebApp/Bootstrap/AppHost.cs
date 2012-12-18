namespace WebApp.Bootstrap
{

    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.WebHost.Endpoints;
    using WebApp.Repositories;
    using WebApp.Services;

    public class CustomUserSession : AuthUserSession
    {
        public string CustomProperty { get; set; }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() 
            : base("StarterTemplate ASP.NET Host", typeof(HelloService).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            //Configure User Defined REST Paths
            Routes.Add<Hello>("/hello")
                  .Add<Hello>("/hello/{Name*}");

            //Uncomment to change the default ServiceStack configuration
            //SetConfig(new EndpointHostConfig {
            //});

            //Enable Authentication
            //ConfigureAuth(container);

            //Register all your dependencies
            container.Register(new TodoRepository());
        }
        /* Uncomment to enable ServiceStack Authentication and CustomUserSession
		private void ConfigureAuth(Funq.Container container)
		{
			var appSettings = new AppSettings();

			//Default route: /auth/{provider}
			Plugins.Add(new AuthFeature(this, () => new CustomUserSession(),
				new IAuthProvider[] {
					new CredentialsAuthProvider(appSettings),
					new FacebookAuthProvider(appSettings),
					new TwitterAuthProvider(appSettings),
					new BasicAuthProvider(appSettings),
				}));

			//Default route: /register
			Plugins.Add(new RegistrationFeature());

			//Requires ConnectionString configured in Web.Config
			var connectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
			container.Register<IDbConnectionFactory>(c =>
				new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance));

			container.Register<IUserAuthRepository>(c =>
				new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

			var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
			authRepo.CreateMissingTables();
		}
		*/
    }
}