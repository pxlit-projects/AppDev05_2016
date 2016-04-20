using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Campaign {
        public int Id { get; set; }
        public string Slogan { get; set; }
        public string Title { get; set; }
        public string Purpose { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public Boolean Active { get; set; }
    }
}