using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Event {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string EntranceFee { get; set; }
        public Boolean AlcoholFree { get; set; }
        public Boolean Active { get; set; }
    }
}