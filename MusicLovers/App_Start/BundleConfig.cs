using System.Web;
using System.Web.Optimization;

namespace MusicLovers
{
    /// <summary>
    /// This class is use for adding scripts into bundles for maintaining and controlling easier
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // This is app bundle
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/Services/attendanceServices.js",
                        "~/Scripts/app/Controllers/attendancesController.js",
                        "~/Scripts/app/Services/followingServices.js",
                        "~/Scripts/app/Controllers/followingsController.js",
                        "~/Scripts/app/Services/gigServices.js",
                        "~/Scripts/app/Controllers/gigsController.js",
                        "~/Scripts/app/app.js"));

            // Lib bundle
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/moment.js"));

            // JQuery bundles
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Css bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/animate.css"));
        }
    }
}
