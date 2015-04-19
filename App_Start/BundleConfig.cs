using System.Web.Optimization;
using System.Web.Optimization.React;

namespace CafeInternational.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.UseCdn = true;   //enable CDN support
            BundleTable.EnableOptimizations = false;  // using Webpack

            // Add React.js
            var react = new ScriptBundle("~/bundles/react", "//fb.me/react-with-addons-0.13.1.min.js")
            .Include("~/node_modules/react/dist/react-with-addons.js");
            react.CdnFallbackExpression = "require('react')";
            bundles.Add(react);

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/client.bundle.js"
            ));
        }

    }
}