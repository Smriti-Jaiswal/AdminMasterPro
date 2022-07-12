using System.Web;
using System.Web.Optimization;

namespace admin_master_pro__mvc_
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Content/js/vendor/jquery-1.11.3.min.js",
                    "~/Content/js/vendor/modernizr-2.8.3.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/jquery.meanmenu.js",
                      "~/Content/js/jquery.mCustomScrollbar.concat.min.js",
                      "~/Content/js/jquery.sticky.js",
                      "~/Content/js/jquery.scrollUp.min.js",
                      "~/Content/js/counterup/jquery.counterup.min.js",
                      "~/Content/js/counterup/waypoints.min.js",
                      "~/Content/js/counterup/counterup-active.js",
                      "~/Content/js/peity/jquery.peity.min.js",
                      "~/Content/js/peity/peity-active.js",
                      "~/Content/js/sparkline/jquery.sparkline.min.js",
                      "~/Content/js/sparkline/sparkline-active.js",
                      "~/Content/js/flot/jquery.flot.js",
                      "~/Content/js/flot/jquery.flot.tooltip.min.js",
                      "~/Content/js/flot/jquery.flot.spline.js",
                      "~/Content/js/flot/jquery.flot.resize.js",
                      "~/Content/js/flot/jquery.flot.pie.js",
                      "~/Content/js/flot/Chart.min.js",
                      "~/Content/js/flot/flot-active.js",
                      "~/Content/js/map/raphael.min.js",
                      "~/Content/js/map/jquery.mapael.js",
                      "~/Content/js/map/france_departments.js",
                      "~/Content/js/map/world_countries.js",
                      "~/Content/js/map/usa_states.js",
                      "~/Content/js/map/map-active.js",
                      "~/Content/js/data-table/bootstrap-table.js",
                      "~/Content/js/data-table/tableExport.js",
                      "~/Content/js/data-table/data-table-active.js",
                      "~/Content/js/data-table/bootstrap-table-editable.js",
                      "~/Content/js/data-table/bootstrap-editable.js",
                      "~/Content/js/data-table/bootstrap-table-resizable.js",
                      "~/Content/js/data-table/colResizable-1.5.source.js",
                      "~/Content/js/data-table/bootstrap-table-export.js",
                      "~/Content/js/datapicker/bootstrap-datepicker.js",
                      "~/Content/js/datapicker/datepicker-active.js",
                      "~/Content/js/data-table/bootstrap-table-cookie.js",
                      "~/Content/js/data-table/bootstrap-table-key-events.js",
                      //"~/Content/js/modal-active.js",
                      "~/Content/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        // "~/Scripts/jquery.validate.unobtrusive*",
                        //"~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                       "~/Content/css/adminpro-custon-icon.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/meanmenu.min.css",
                      "~/Content/css/jquery.mCustomScrollbar.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/data-table/bootstrap-table.css",
                      "~/Content/css/data-table/bootstrap-editable.css",
                      "~/Content/css/normalize.css",
                      "~/Content/css/c3.min.css",
                      "~/Content/css/form/all-type-forms.css",
                      "~/Content/css/style.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/modals.css",
                      "~/Content/css/datapicker/datepicker3.css",
                       "~/Content/css/datetimepicker.css"


                     ));

        }
    }
}