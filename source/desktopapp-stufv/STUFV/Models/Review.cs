﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace STUFV
{
    [Table("Reviews")]
    public class Review {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Flagged { get; set; }

        [Required]
        public Boolean Handled { get; set; }

        public int Rating { get; set; }

        [Required]
        public string DateTime { get; set; }

        public Boolean Active { get; set; }
    }
}