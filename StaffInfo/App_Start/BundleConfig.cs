using System.Web;
using System.Web.Optimization;

namespace StaffInfo
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

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/plugins/jQueryUI/jquery-ui.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/plugins/morris/morris.min.js",
                "~/Scripts/plugins/chart.js/Chart.min.js",
                "~/Scripts/plugins/flot/jquery.flot.js",
                "~/Scripts/plugins/flot/jquery.flot.resize.js",
                "~/Scripts/plugins/flot/query.flot.pie.js",
                "~/Scripts/plugins/flot/jquery.flot.categories.js",
                "~/Scripts/plugins/sparkline/jquery.sparkline.min.js",
                "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/plugins/knob/jquery.knob.js",
                "~/Scripts/plugins/pace/pace.min.js",
                "~/Scripts/ckeditor/ckeditor.js",
                "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                //"~/Scripts/plugins/datepicker/dist/js/bootstrap-datepicker.min.js",
                "~/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.js",
                "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/Scripts/plugins/fastclick/fastclick.js",
                "~/Scripts/dist/js/plugins/adminlte.min.js",
                "~/Scripts/dist/js/plugins/demo.js",
                "~/Scripts/plugins/bootstrap-slider/bootstrap-slider.js",
                "~/Scripts/plugins/select2/select2.full.min.js",
                "~/Scripts/plugins/input-mask/jquery.inputmask.js",
                "~/Scripts/plugins/input-mask/jquery.inputmask.date.extensions.js",
                "~/Scripts/plugins/input-mask/jquery.inputmask.extensions.js",
                "~/Scripts/plugins/timepicker/bootstrap-timepicker.min.js",
                "~/Scripts/plugins/iCheck/icheck.min.js",
                "~/Scripts/plugins/fullcalendar/dist/fullcalendar.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/dashboard1")
            //    "js/pages/dashboard.js"));

            //bundles.Add(new ScriptBundle("~/bundles/dashboard2")
            //    "js/pages/dashboard2.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                      "~/Scripts/plugins/ckeditor/ckeditor.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css",
                    "~/Content/dataTables.bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/themes/base/jquery-ui.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/themes/base/jquery-ui.min.css",
                    "~/Scripts/dist/css/adminlte.min.css",
                    "~/Scripts/plugins/morris/morris.css",
                    "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                    "~/Scripts/plugins/datepicker/datepicker3.css",
                    "~/Scripts/plugins/daterangepicker/daterangepicker-bs3.css",
                    "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                    "~/Scripts/plugins/select2/select2.min.css",
                    "~/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.css",
                    "~/Scripts/plugins/timepicker/bootstrap-timepicker.min.css",
                    "~/Scripts/plugins/iCheck/all.css",
                    "~/Scripts/plugins/pace/pace.min.css",
                    "~/Scripts/plugins/fullcalendar/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/jquery-3.3.1.js",
                    "~/Scripts/jquery-ui-1.12.1.min.js",
                    "~/Scripts/jquery-ui-1.12.1.js",
                    "~/Scripts/jquery.dataTables.min.js",
                    "~/Scripts/dataTables.bootstrap.min.js",
                    "~/Scripts/Staff_JS/Staff.js"
                ));
        }
    }
}
