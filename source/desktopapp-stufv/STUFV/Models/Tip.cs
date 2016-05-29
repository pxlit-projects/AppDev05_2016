using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace STUFV
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
