using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mongo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index" } );
            routes.MapRoute("PostView", "PostView/{id}", new { controller = "Home", action = "PostView", Id = (string)null });
            routes.MapRoute("PostEdit", "PostEdit/{id}", new { controller = "Home", action = "PostEdit", Id = (string)null });
            routes.MapRoute("PostDelete", "PostDelete/{id}", new { controller = "Home", action = "PostDelete", Id = (string)null });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());

        }

        protected void Session_Start()
        {
            Session["AdminMode"] = false;
        }
    }
}