using System.Web;
using System.Web.Mvc;

namespace hasselt_events {
    public class FilterConfig {
        public static void RegisterGlobalFilters ( GlobalFilterCollection filters ) {
            filters.Add ( new HandleErrorAttribute ( ) );
        }
    }
}
