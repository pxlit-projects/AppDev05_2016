using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models
{
    [Table("ProfileSettings")]
    public class ProfileSettings
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Boolean Email { get; set; }
        [Required]
        public Boolean FirstName { get; set; }
        [Required]
        public Boolean LastName { get; set; }
        [Required]
        public Boolean BirthDate { get; set; }
        [Required]
        public Boolean Street { get; set; }
        [Required]
        public Boolean ZipCode { get; set; }
        [Required]
        public Boolean MobileNr { get; set; }
        [Required]
        public Boolean TelNr { get; set; }

        public static List<ProfileSettings> GetAllProfileSettings()
        {
            using (var context = new STUFVModelContext())
            {
                return context.ProfileSettings.ToList();
            }
        }
    }
}