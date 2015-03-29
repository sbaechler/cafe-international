using System.Web.Optimization;
using System.Web.Optimization.React;

namespace CafeInternational.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.UseCdn = true;   //enable CDN support
            BundleTable.EnableOptimizations = true;

            // Add React.js
            var react = new ScriptBundle("~/bundles/react", "//fb.me/react-with-addons-0.13.1.min.js")
            .Include("~/Content/lib/react/react-with-addons.min.js");
            react.CdnFallbackExpression = "window.React";
            bundles.Add(react);

            bundles.Add(new JsxBundle("~/bundles/main").Include(
                // Add your JSX files here
                "~/Content/jsx/main.jsx"
                // You can include regular JavaScript files in the bundle too
                // "~/Content/ajax.js"
            ));
        }

    }
}