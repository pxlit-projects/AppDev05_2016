using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webapp_stufv.Models
{
    [Table("EventTypes")]
    public class EventTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Event> events { get; set; }
    }
}