using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Attendance")]
    public class Attendance {
        [Key, Column(Order = 0), ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Key, Column(Order = 1), ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Boolean Active { get; set; }
    
    public void Attend(int userId, int eventId) {
            var Attendace = new Attendance { EventId = eventId, UserId = userId, Active = true };
            using (var context = new STUFVModelContext())
            {
                context.Attendances.Add(Attendace);
                context.SaveChanges();
            }

        }
    }
}