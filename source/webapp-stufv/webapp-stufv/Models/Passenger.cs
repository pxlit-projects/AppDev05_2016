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
    }
}