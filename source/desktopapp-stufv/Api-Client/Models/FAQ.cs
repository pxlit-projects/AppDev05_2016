using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    [Table("FAQ")]
    public class FAQ {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public Boolean Active { get; set; }

        // Methods
        public static List<FAQ> getAllFAQ() {
            using ( var context = new STUFVModelContext ( ) ) {
                return context.FAQs.ToList ( );
            }
        }
    }
}