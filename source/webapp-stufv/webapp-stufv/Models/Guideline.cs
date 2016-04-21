using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Guideline")]
    public class Guideline {
        [Key]
        public int Id { get; set; }

        public string Short { get; set; }
        public string Content { get; set; }
    }
}