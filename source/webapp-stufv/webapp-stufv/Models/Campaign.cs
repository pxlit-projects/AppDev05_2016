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
<<<<<<< HEAD
<<<<<<< HEAD

        public virtual ICollection<Article> articles { get; set; }
=======
    
>>>>>>> d698a12a67ea04139fa139a936bf8e4c72b16a68
=======
>>>>>>> 5dde771bac6a6bc8ed81ec91483665846dd5b21f
    }
}