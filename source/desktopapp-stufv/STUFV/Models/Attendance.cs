﻿using System;
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

        public static void UnSignAttend(int userId, int eventId)
        {
            if (IsAttending(userId, eventId))
            {
                using (var context = new STUFVModelContext())
                {
                    var attendance = context.Attendances.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    attendance.Active = false;
                    context.SaveChanges();
                }
            }
        }

        public static void SignAttend(int userId, int eventId)
        {
            if (WasAttending(userId, eventId))
            {
                //already in db active == false
                using (var context = new STUFVModelContext())
                {
                    var attendance = context.Attendances.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    attendance.Active = true;
                    context.SaveChanges();
                }

            }
            else {
                var Attendace = new Attendance { EventId = eventId, UserId = userId, Active = true };
                using (var context = new STUFVModelContext())
                {
                    context.Attendances.Add(Attendace);
                    context.SaveChanges();
                }
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
                if (attendance.ElementAt(x).UserId.Equals(userId) && attendance.ElementAt(x).EventId.Equals(eventId) && attendance.ElementAt(x).Active.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool WasAttending(int userId, int eventId)
        {
            List<Attendance> attendance = GetAllAttendance();
            int x;
            for (x = 0; x < attendance.Count(); x++)
            {
                if (attendance.ElementAt(x).UserId.Equals(userId) && attendance.ElementAt(x).EventId.Equals(eventId) && attendance.ElementAt(x).Active.Equals(false))
                {
                    return true;
                }
            }
            return false;
        }
    }
}