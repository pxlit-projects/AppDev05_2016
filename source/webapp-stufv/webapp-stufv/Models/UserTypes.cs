using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models
{
    [Table("UserTypes")]
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20), Required]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}