using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace webapp_stufv.Models {
    [Table("User")]
    public class User {
        [Key]
        public int Id { get; set; }

        [MaxLength(30), Required]
        public string FirstName { get; set; }
        [MaxLength(30), Required]
        public string LastName { get; set; }
        [MaxLength(20), Required]
        public string PassWord { get; set; }
        public string Salt { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }

        public char Sex { get; set; }
        [ForeignKey("Cities")]
        public string ZipCode { get; set; }
        [MaxLength(30), Required]
        public string Email { get; set; }
        public string TelNr { get; set; }
        
        public string MobileNr { get; set; }
        [ForeignKey("UserTypes"), Required]
        public int RoleID { get; set; }
        public virtual UserTypes Usertype { get; set; }
        [Required]
        public Boolean Active { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
    }
}