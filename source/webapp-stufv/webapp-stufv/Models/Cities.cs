using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Cities")]
    public class Cities {
        [Key]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        public virtual ICollection<User> users { get; set; }

        public virtual ICollection<Event> events { get; set; }
    }
}