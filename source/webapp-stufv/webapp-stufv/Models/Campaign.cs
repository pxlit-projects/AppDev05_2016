using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_stufv.Models {
    [Table("Campaign")]
    public class Campaign {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Slogan { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Purpose { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}