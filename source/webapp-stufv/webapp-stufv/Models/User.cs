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

        [MaxLength(40), Required]
        public string PassWord { get; set; }
        public string Salt { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        public char Sex { get; set; }

        [ForeignKey("Cities")]
        public string ZipCode { get; set; }
        public virtual Cities Cities { get; set; }

        [MaxLength(30), Required]
        public string Email { get; set; }

        public string TelNr { get; set; }
        public string MobileNr { get; set; }

        [ForeignKey("UserTypes")]
        public int RoleID { get; set; }
        public virtual UserTypes UserTypes { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

        public virtual ICollection<DesDriver> DesDrivers { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }

        // Methods
        public static Boolean Login (string email, string password) {
            using ( var context = new STUFVModelContext ( ) ) {
                List<User> users = context.Users.ToList ( );

                int x;

                for (x=0; x < users.Count ( ); x++) {
                    if ( users.ElementAt ( x ).Email.Equals ( email ) && users.ElementAt ( x ).PassWord.Equals ( password ) )
                        return true;
                }

                return false;
            }
        }
    }
}