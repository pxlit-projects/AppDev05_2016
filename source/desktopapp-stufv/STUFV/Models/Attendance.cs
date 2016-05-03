using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STUFV
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key, Column(Order = 0), ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Key, Column(Order = 1), ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Boolean Active { get; set; }

        
    }
}