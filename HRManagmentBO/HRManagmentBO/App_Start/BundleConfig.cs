using System.Web;
using System.Web.Optimization;

namespace HRManagmentBO
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.min.css",
            "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            // Bootstrap angular directives
            bundles.Add(new ScriptBundle("~/bundles/angular-bootstarp-ui")
                .IncludeDirectory("~/Scripts/Angular-ui", "*.js"));

            // Angular js bundles
            bundles.Add(new ScriptBundle("~/bundles/angulr-js")
                .Include(
                    "~/Scripts/Angular-js/angular.min.js",
                    "~/Scripts/Angular-js/angular-animate.min.js",
                    "~/Scripts/Angular-js/angular-route.min.js",
                    "~/Scripts/Angular-js/angular-touch.min.js"
                ).IncludeDirectory("~/Scripts/dashboard/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/dashboard/Services", "*.js")
                .IncludeDirectory("~/Scripts/dashboard/Factories", "*.js")
                .Include("~/Scripts/Dashboard/app.js")
                );
            // Angular Highchart directives
            bundles.Add(new ScriptBundle("~/bundles/angular-highchart")
             .IncludeDirectory("~/Scripts/Highcharts-ng", "*.js"));

            // Hichart core files
            bundles.Add(new ScriptBundle("~/bundles/hichart-core")
                .Include(
                    "~/Scripts/highstock.js",
                    "~/Scripts/Highcharts/highcharts-more.js",
                    "~/Scripts/Highcharts/modules/exporting.js",
                    "~/Scripts/Highcharts/modules/solid-gauge.js",
                     "~/Scripts/Highcharts/dark-unica.js"
                ));

            // Jquery ui for Highchart
            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                "~/Content/base/all.css",
                "~/Content/site.css"));

            // Jquery ui for Highchart
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui-js")
                .IncludeDirectory("~/Scripts/Jquery-ui", "*.js"));

            // SignalR files
            bundles.Add(new ScriptBundle("~/bundles/signalr")
            .Include("~/Scripts/jquery.signalR-2.2.0.min.js")
                .Include("~/Scripts/jquery.signalR-2.2.0.js"));
        }
    }
}
