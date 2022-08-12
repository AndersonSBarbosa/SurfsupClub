using System.Web;
using System.Web.Optimization;

namespace ADMSurfsupClub
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/js/jquery.min.js",
                "~/Scripts/js/bootstrap.min.js",
                "~/Scripts/js/nicescroll/jquery.nicescroll.min.js",
                "~/Scripts/js/chartjs/chart.min.js",
                "~/Scripts/js/progressbar/bootstrap-progressbar.min.js",
                "~/Scripts/js/moment.min2.js",
                "~/Scripts/js/datepicker/daterangepicker.js",
                "~/Scripts/js/sparkline/jquery.sparkline.min.js",
                "~/Scripts/js/custom.js",
                "~/Scripts/js/flot/jquery.flot.js",
                "~/Scripts/js/flot/jquery.flot.pie.js",
                "~/Scripts/js/flot/jquery.flot.orderBars.js",
                "~/Scripts/js/flot/date.js",
                "~/Scripts/js/flot/jquery.flot.spline.js",
                "~/Scripts/js/flot/jquery.flot.stack.js",
                "~/Scripts/js/flot/curvedLines.js",
                "~/Scripts/js/datatables/js/jquery.dataTables.js",
                "~/Scripts/js/datatables/tools/js/dataTables.tableTools.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/floatexamples.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ion.rangeSlider.css",
                      "~/Content/ion.rangeSlider.skinFlat.css",
                      "~/Content/normalize.css",
                      "~/Content/nprogress.css",
                      "~/Content/custom.css",
                      "~/Content/maps/jquery-jvectormap-2.0.1.css",
                      "~/Content/icheck/flat/green.css",
                      "~/Content/datatables/tools/css/dataTables.tableTools.css",
                      "~/Content/icheck/flat/floatexamples.css"));
        }
    }
}
