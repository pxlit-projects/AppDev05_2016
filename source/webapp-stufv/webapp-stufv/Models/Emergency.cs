using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Emergency {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNr { get; set; }
        public Boolean Active { get; set; }

       
    }
}