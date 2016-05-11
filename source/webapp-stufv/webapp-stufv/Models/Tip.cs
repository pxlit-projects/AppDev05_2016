using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models
{
    [Table("Tip")]
    public class Tip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipText { get; set; }
        [Required]
        public Boolean Active { get; set; }


    }
}