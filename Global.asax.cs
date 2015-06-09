using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using CafeInternational.App_Start;
using System.Web.Optimization;

namespace CafeInternational
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
