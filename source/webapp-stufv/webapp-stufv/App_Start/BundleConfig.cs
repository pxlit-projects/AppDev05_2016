using System.Web;
using System.Web.Optimization;

namespace webapp_stufv {
    public class BundleConfig {
        public static void RegisterBundles( BundleCollection bundles ) {

            bundles.Add( new ScriptBundle( "~/bundles/scripts" ).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/bootstrap-switch.min.js",
                      "~/Scripts/modernizr-*",
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/global.js",
                      "~/Scripts/jquery-12.4.js") );

            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/global.css",
                      "~/Content/bootstrap-datetimepicker.min.css") );
        }
    }
}
