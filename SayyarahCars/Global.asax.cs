using COMMON;
using System;
using System.Web.Optimization;
using System.Web.Routing;

namespace SayyarahCars
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //Code that runs on application startup

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_End()
        {

        }
    }
}