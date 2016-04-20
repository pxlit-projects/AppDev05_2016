using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Attendance")]
    public class Attendance {
        [Key]
        public int EventId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [Required]
        public Boolean Active { get; set; }
    }
}