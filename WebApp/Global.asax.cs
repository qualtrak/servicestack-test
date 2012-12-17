namespace WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;

    public class Global : System.Web.HttpApplication
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("api/{*pathInfo}");
        //    routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" }); //Prevent exceptions for favicon
        //}

        protected void Application_Start(object sender, EventArgs e)
        {
            //RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object src, EventArgs e)
        {
            if (Request.IsLocal)
            {
                ServiceStack.MiniProfiler.Profiler.Start();
            }
        }

        protected void Application_EndRequest(object src, EventArgs e)
        {
            ServiceStack.MiniProfiler.Profiler.Stop();
        }
    }
}