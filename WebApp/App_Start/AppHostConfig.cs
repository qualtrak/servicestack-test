[assembly: WebActivator.PreApplicationStartMethod(typeof(WebApp.App_Start.AppHostConfig), "Start")]

namespace WebApp.App_Start
{
    using WebApp.Bootstrap;

    public class AppHostConfig
    {
        public static void Start()
        {
            new AppHost().Init();
        }
    }
}