using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STUFV
{
    [Table("Guideline")]
    public class Guideline {
        [Key]
        public int Id { get; set; }
        public string Short { get; set; }
        public string Content { get; set; }
        public Boolean active { get; set; }

        // Methods
        public static List<Guideline> getAllGuideLines() {
            using ( var context = new STUFVModelContext ( ) ) {
                return context.Guidelines.ToList ( );
            }
        }
    }
}