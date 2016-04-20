using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class FAQ {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Boolean Active { get; set; }
    }
}