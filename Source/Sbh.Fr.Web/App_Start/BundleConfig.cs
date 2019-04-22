using System.Web;
using System.Web.Optimization;

namespace Sbh.Fr.Web
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/assets/css/font-awesome.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Persada/css").Include(
                     "~/Content/Persada/css/custom-persada.css",
                      "~/Content/Persada/css/bootstrap-social.css"));

            bundles.Add(new ScriptBundle("~/Persada/js").Include(
                     "~/Content/Persada/js/Helpers/Modal.js",
                     "~/Content/Persada/js/Helpers/Common.js",
                     "~/Content/Persada/js/Helpers/ResultStatus.js"
                     ));

            bundles.Add(new StyleBundle("~/Gemagrafi/css").Include(
                  "~/Content/Gemagrafi/css/style.css"));

            bundles.Add(new StyleBundle("~/Metronic/css").Include(
                   "~/Content/Metronics/global/plugins/font-awesome/css/font-awesome.min.css",
                   "~/Content/Metronics/global/plugins/simple-line-icons/simple-line-icons.min.css",
                   "~/Content/Metronics/global/plugins/bootstrap/css/bootstrap.min.css",
                   "~/Content/Metronics/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                   "~/Content/Metronics/global/plugins/gritter/css/jquery.gritter.css",
                   "~/Content/Metronics/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css",
                   "~/Content/Metronics/global/plugins/fullcalendar/fullcalendar.min.css",
                   "~/Content/Metronics/global/plugins/pages/css/tasks.css",
                   "~/Content/Metronics/global/plugins/css/components.css",
                   "~/Content/Metronics/global/plugins/css/plugins.css",
                   "~/Content/Metronics/global/plugins/layout/css/layout.css",
                   "~/Content/Metronics/global/plugins/layout/css/themes/default.css",
                   "~/Content/Metronics/global/plugins/layout/css/custom.css",
                   "~/Content/Metronics/global/plugins/bootstrap-datepicker/css/datepicker3.css",
                   "~/Content/Metronics/global/plugins/bootstrap-datepicker/css/datepicker.css",
                   "~/Content/Metronics/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css"
                   ));

            bundles.Add(new ScriptBundle("~/Metronic/js").Include(
            "~/Scripts/bootstrap.min.js",
            "~/Content/Metronics/global/plugins/scripts/moment.min.js",
            "~/Content/Metronics/global/plugins/fullcalendar/fullcalendar.min.js",
            "~/Content/Metronics/global/plugins/jquery-ui/jquery-ui.min.js",
            "~/Content/Metronics/global/plugins/scripts/app.min.js",
            "~/Content/Metronics/global/plugins/fullcalendar/calendar.min.js",
            "~/Content/Metronics/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
            "~/Content/Metronics/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
            "~/Content/Metronics/global/plugins/flot/jquery.flot.min.js",
            "~/Content/Metronics/global/plugins/flot/jquery.flot.resize.min.js",
            "~/Content/Metronics/global/plugins/flot/jquery.flot.categories.min.js",
            "~/Content/Metronics/global/plugins/jquery.pulsate.min.js",
            "~/Content/Metronics/global/plugins/bootstrap-daterangepicker/daterangepicker.js",
            "~/Content/Metronics/global/plugins/gritter/js/jquery.gritter.js",
            "~/Scripts/bootstrap-datetimepicker.min.js",
            "~/Content/Metronics/global/plugins/scripts/metronic.js",
            "~/Content/Metronics/global/plugins/layout/scripts/layout.js",
            "~/Content/Metronics/global/plugins/layout/scripts/quick-sidebar.js",
            "~/Content/Metronics/global/plugins/pages/scripts/index.js",
            "~/Content/Metronics/global/plugins/pages/scripts/tasks.js"
           ));

            bundles.Add(new StyleBundle("~/MetronicPure/css").Include(
            "~/Content/MetronicPureMenu_files/css",
            "~/Content/MetronicsPure/font-awesome.min.css",
            "~/Content/MetronicsPure/simple-line-icons/simple-line-icons.css",
            "~/Content/MetronicsPure/bootstrap.min.css",
            "~/Content/MetronicsPure/bootstrap-switch.min.css",
            "~/Content/MetronicsPure/bootstrap-social.css",
            "~/Content/MetronicsPure/components.min.css",
            "~/Content/MetronicsPure/plugins.min.css",
            "~/Content/MetronicsPure/layout.min.css",
            "~/Content/MetronicsPure/default.min.css",
            "~/Content/MetronicsPure/custom.min.css"));


            bundles.Add(new ScriptBundle("~/MetronicPure/js").Include(
            "~/Content/MetronicsPure/jquery.slimscroll.min.js",
            "~/Content/MetronicsPure/app.min.js",
            "~/Content/MetronicsPure/layout.min.js",
            "~/Content/MetronicsPure/demo.min.js",
            "~/Content/MetronicsPure/quick-sidebar.min.js",
            "~/Content/MetronicsPure/quick-nav.min.js",
            "~/Content/MetronicsPure/bootstrap/js/bootstrap.js",
            "~/Content/MetronicsPure/pages/scripts/index.js"
           ));

            bundles.Add(new StyleBundle("~/Floara/css").Include(
              "~/Content/Floara/css/froala_editor.css",
              "~/Content/Floara/css/froala_style.css",
              "~/Content/Floara/css/plugins/code_view.css",
              "~/Content/Floara/css/plugins/colors.css",
              "~/Content/Floara/css/plugins/emoticons.css",
              "~/Content/Floara/css/plugins/image_manager.css",
              "~/Content/Floara/css/plugins/image.css",
              "~/Content/Floara/css/plugins/line_breaker.css",
              "~/Content/Floara/css/plugins/table.css",
              "~/Content/Floara/css/plugins/char_counter.css",
              "~/Content/Floara/css/plugins/video.css",
              "~/Content/Floara/css/plugins/fullscreen.css",
              "~/Content/Floara/css/plugins/file.css"));


            bundles.Add(new ScriptBundle("~/Floara/js").Include(
              "~/Content/Floara/js/froala_editor.min.js",
              "~/Content/Floara/js/plugins/align.min.js",
              "~/Content/Floara/js/plugins/code_beautifier.min.js",
              "~/Content/Floara/js/plugins/code_view.min.js",
              "~/Content/Floara/js/plugins/colors.min.js",
              "~/Content/Floara/js/plugins/draggable.min.js",
              "~/Content/Floara/js/plugins/emoticons.min.js",
              "~/Content/Floara/js/plugins/font_size.min.js",
              "~/Content/Floara/js/plugins/font_family.min.js",
              "~/Content/Floara/js/plugins/image.min.js",
              "~/Content/Floara/js/plugins/file.min.js",
              "~/Content/Floara/js/plugins/image_manager.min.js",
              "~/Content/Floara/js/plugins/line_breaker.min.js",
              "~/Content/Floara/js/plugins/link.min.js",
              "~/Content/Floara/js/plugins/lists.min.js",
              "~/Content/Floara/js/plugins/paragraph_format.min.js",
              "~/Content/Floara/js/plugins/paragraph_style.min.js",
              "~/Content/Floara/js/plugins/video.min.js",
              "~/Content/Floara/js/plugins/table.min.js",
              "~/Content/Floara/js/plugins/url.min.js",
              "~/Content/Floara/js/plugins/entities.min.js",
              "~/Content/Floara/js/plugins/char_counter.min.js",
              "~/Content/Floara/js/plugins/inline_style.min.js",
              "~/Content/Floara/js/plugins/save.min.js",
              "~/Content/Floara/js/plugins/fullscreen.min.js",
              "~/Content/Floara/js/languages/ro.js"
           ));
        }
    }
}

