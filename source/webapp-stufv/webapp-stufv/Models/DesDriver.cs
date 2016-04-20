using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class DesDriver {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int NrOfPlaces { get; set; }
        public int NrOfFilled { get; set; }
        public Boolean Flagged { get; set; }
        public Boolean Active { get; set; }
    }
}