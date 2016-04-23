using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models
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

        public static void SignAttend(int userId, int eventId)
        {
            var Attendace = new Attendance { EventId = eventId, UserId = userId, Active = true };
            using (var context = new STUFVModelContext())
            {
                context.Attendances.Add(Attendace);
                context.SaveChanges();
            }

        }
        private static List<Attendance> GetAllAttendance()
        {
            using (var context = new STUFVModelContext())
            {
                List<Attendance> attendance = new List<Attendance>();
                attendance = context.Attendances.ToList();
                return attendance;
            }
        }
        public static bool IsAttending(int userId, int eventId)
        {
            List<Attendance> attendance = GetAllAttendance();
            int x;
            for (x = 0; x < attendance.Count(); x++)
            {
                if (attendance.ElementAt(x).UserId.Equals(userId) && attendance.ElementAt(x).EventId.Equals(eventId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}