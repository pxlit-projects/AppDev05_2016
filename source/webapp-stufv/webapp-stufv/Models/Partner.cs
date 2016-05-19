using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public String URL { get; set; }

        [Required]
        public Boolean Active { get; set; }     
    }
}