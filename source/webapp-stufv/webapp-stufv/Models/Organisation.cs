﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    [Table("Organisation")]
    public class Organisation {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Boolean Active { get; set; }

        [Required]
        public Boolean isRegistered { get; set; }

        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Event> Events { get; set; }

      
    }
}