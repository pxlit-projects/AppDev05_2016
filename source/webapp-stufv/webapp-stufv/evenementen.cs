using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv
{
    public class Evenementen
    {
        public int id { get; set; }
        public String name { get; set; }
        public String details { get; set; }
        public String type { get; set; }
        public String straat { get; set; }
        public String postalcode { get; set; }
        public String startHour { get; set; }
        public String endHour { get; set; }
        public bool achocoholFree { get; set; }
    }
}