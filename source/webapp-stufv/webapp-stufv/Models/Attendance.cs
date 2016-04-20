using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Attendance {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public Boolean Active { get; set; }
    }
}