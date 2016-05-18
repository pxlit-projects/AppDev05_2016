using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using webapp_stufv.Repository;

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
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Accepted { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual DesDriver DesDriver { get; set;}

        public string GetPassengerName()
        {
            IPassengerRepository ipas = new PassengerRepository();
            return ipas.GetPassengerName(UserId);
        }
        public string GetProfilePicture()
        {
            IPassengerRepository ipas = new PassengerRepository();
            return ipas.GetProfilePicture(UserId);
        }
    }
}