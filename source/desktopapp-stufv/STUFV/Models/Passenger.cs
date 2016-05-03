using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace STUFV
{
    [Table("Passenger")]
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("DesDriver")]
        public int DesDriverId { get; set; }

        public virtual User User { get; set; }
        public virtual DesDriver DesDriver { get; set;}

        
    }
}