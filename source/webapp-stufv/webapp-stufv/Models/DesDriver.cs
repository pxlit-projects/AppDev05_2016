using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("DesDriver")]
    public class DesDriver {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        public int NrOfPlaces { get; set; }

        [Required]
        public int NrOfFilled { get; set; }

        [Required]
        public Boolean Flagged { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public static List<DesDriver> ActiveDriversPerEvent(int eventId) {
            List<DesDriver> allDrivers = GetAllDrivers();
            List<DesDriver> activeDrivers = new List<DesDriver>();
            int x;
            for (x = 0; x < allDrivers.Count(); x++)
            {
                if (allDrivers.ElementAt(x).EventId.Equals(eventId) && allDrivers.ElementAt(x).Active.Equals(true))
                {
                    activeDrivers.Add(allDrivers.ElementAt(x));
                }
            }
            return activeDrivers;
        }

        public static void unSetDES(int userId, int eventId) {
            if (IsDES(userId, eventId))
            {
                using (var context = new STUFVModelContext())
                {
                    var drivers = context.DesDrivers.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    drivers.Active = false;
                    context.SaveChanges();
                }
            }
        }

        public static void SetDES(int userId, int eventId, int places) {
            if (WasDES(userId, eventId))
            {
                //already in db active == false
                using (var context = new STUFVModelContext())
                {
                    var driver = context.DesDrivers.FirstOrDefault(c => c.UserId == userId && c.EventId == eventId);
                    driver.Active = true;
                    driver.NrOfPlaces = places;
                    context.SaveChanges();
                }

            }
            else {
                var driver = new DesDriver{ EventId = eventId, UserId = userId, Active = true, NrOfPlaces = places, NrOfFilled = 0, Flagged = false};
                using (var context = new STUFVModelContext())
                {
                    context.DesDrivers.Add(driver);
                    context.SaveChanges();
                }
            }
        }

        public static List<DesDriver> GetAllDrivers() {
            using (var context = new STUFVModelContext())
            {
                List<DesDriver> drivers = new List<DesDriver>();
                drivers = context.DesDrivers.ToList();
                return drivers;
            }
        }

        public static bool IsDES(int userId, int eventId) {
            List<DesDriver> drivers = GetAllDrivers();
                int x;
                for (x = 0; x < drivers.Count(); x++)
                {
                    if (drivers.ElementAt(x).UserId.Equals(userId) && drivers.ElementAt(x).EventId.Equals(eventId) && drivers.ElementAt(x).Active.Equals(true))
                    {
                        return true;
                    }
            }
                return false;
        }
        private static bool WasDES(int userId, int eventId)
        {
            List<DesDriver> drivers = GetAllDrivers();
            int x;
            for (x = 0; x < drivers.Count(); x++)
            {
                if (drivers.ElementAt(x).UserId.Equals(userId) && drivers.ElementAt(x).EventId.Equals(eventId) && drivers.ElementAt(x).Active.Equals(false))
                {
                    return true;
                }
            }
            return false;
        }
    }
}