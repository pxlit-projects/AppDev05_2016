using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapp_stufv.Repository;

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

        public virtual ICollection<Passenger> Passengers { get; set; }

        public int GetFreeSpaces()
        {
            IPassengerRepository ipassenger = new PassengerRepository();
            int passengerCount = 0;
            passengerCount = ipassenger.PassengersPerDriver(Id);
            return NrOfPlaces - passengerCount;
        }
        public string GetDriverName() {
            IDesDriverRepository ides = new DesDriverRepository();
            return ides.GetDriverName(UserId);
        }
    }
}