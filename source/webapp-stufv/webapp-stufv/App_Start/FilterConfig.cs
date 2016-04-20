using System.Web;
using System.Web.Mvc;

namespace webapp_stufv {
    public class FilterConfig {
        public static void RegisterGlobalFilters ( GlobalFilterCollection filters ) {
            filters.Add ( new HandleErrorAttribute ( ) );
        }
    }
}
