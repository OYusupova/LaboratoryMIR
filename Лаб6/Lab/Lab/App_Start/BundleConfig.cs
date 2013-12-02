using System.Web.Optimization;

namespace Lab
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //            "~/Scripts/knockout-3.0.0.js",
            //            "~/Scripts/knockout.mapping.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include("~/Content/bootstrap*"));
            bundles.Add(new StyleBundle("~/Content/SignIn").Include("~/Content/SignIn.css"));
            bundles.Add(new StyleBundle("~/Content/Registrer").Include("~/Content/Registrer.css"));
            bundles.Add(new StyleBundle("~/Content/Site").Include("~/Content/Site.css"));
        }
    }
}