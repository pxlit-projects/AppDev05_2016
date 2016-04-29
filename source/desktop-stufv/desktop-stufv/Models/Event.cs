using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Event")]
    public class Event {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Organisation")]
        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("EventTypes")]
        public int Type { get; set; }
        public virtual EventTypes EventTypes { get; set; }

        [Required, MaxLength(35)]
        public string Street { get; set; }

        [ForeignKey("Cities")]
        public string ZipCode { get; set; }
        public virtual Cities Cities { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public double EntranceFee { get; set; }

        [Required]
        public Boolean AlcoholFree { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<DesDriver> DesDrivers { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public string getCity() {
            List < Cities > cities = new List<Cities>();
            using (var context = new STUFVModelContext())
            {
                cities = context.Cities.ToList();
                var city = cities.Single(r => r.ZipCode == ZipCode);
                return (string)city.City;
            }
        }
        public static List<Event> GetAllEvents()
        {
            using (var context = new STUFVModelContext())
            {
                List < Event > events = new List<Event>();
                events = context.Events.ToList();
                return events;
            }
        }
    }
}