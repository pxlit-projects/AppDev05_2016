using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    [Table("Reviews")]
    public class Review {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Flagged { get; set; }
        public int Rating { get; set; }
        [Required]
        public string DateTime { get; set; }
        public Boolean Active { get; set; }
    }
}