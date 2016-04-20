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
        public virtual Organisation organisation { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("EventTypes"), Required]
        public string Type { get; set; }
        public virtual EventTypes eventTypes { get; set; }

        [Required, MaxLength(35)]
        public string Street { get; set; }

        [ForeignKey("Cities"), Required]
        public string ZipCode { get; set; }
        public virtual Cities cities { get; set; }

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

        public virtual ICollection<Attendance> attendances { get; set; }

        public virtual ICollection<Review> reviews { get; set; }

        public virtual ICollection<DesDriver> desDrivers { get; set; }
    }
}