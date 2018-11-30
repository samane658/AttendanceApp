using System.Web;
using System.Web.Optimization;

namespace AttendanceApp
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
                      "~/Scripts/bootstrap-rtl.js",
                      "~/Scripts/MdBootstrapPersianDateTimePicker/jalaali.js",
                      "~/Scripts/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.js",
                      "~/Scripts/bootstrap-rtl.js",
                      "~/vendor/jquery/jquery.min.js",
                      "~/vendor/metisMenu/metisMenu.min.js",
                      "~/dist/js/sb-admin-2.js"
                      
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap-rtl.css",
                       "~/Content/bootstrap-theme-rtl.css",   
                       "~/Content/font-awesome.css",
                       "~/fonts/vazir.css",
                       "~/vendor/metisMenu/metisMenu.min.css",
                       "~/Content/site.css",
                       "~/Content/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.css"
                       ));
        }
    }
}
  