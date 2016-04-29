using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models
{
    [Table("Passenger")]
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("DesDriver")]
        public int DesDriverId { get; set; }

        public virtual User User { get; set; }
        public virtual DesDriver DesDriver { get; set;}

        public static List<Passenger> GetAllPassengers()
        {
            using (var context = new STUFVModelContext())
            {
                List<Passenger> passengers = new List<Passenger>();
                passengers = context.Passengers.ToList();
                return passengers;
            }
        }
        public static void NewPassenger(int userId, int desId) {
            var passenger = new Passenger{UserId = userId, DesDriverId = desId};
            using (var context = new STUFVModelContext())
            {
                context.Passengers.Add(passenger);
                context.SaveChanges();
            }
        }
        public static int PassengersPerDriver(int id) {
            int count = 0;
            List<Passenger> passengers = GetAllPassengers();
            int x;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).DesDriverId.Equals(id))
                {
                    count += 1;
                }
            }

            return count;
        }
        public static bool IsPassenger(int driverId, int userId) {
            List<Passenger> passengers = GetAllPassengers();
            int x;
            for (x = 0; x < passengers.Count(); x++)
            {
                if (passengers.ElementAt(x).DesDriverId.Equals(driverId) && passengers.ElementAt(x).UserId.Equals(userId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}