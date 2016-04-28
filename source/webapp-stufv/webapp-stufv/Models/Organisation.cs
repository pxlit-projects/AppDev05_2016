using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    [Table("Organisation")]
    public class Organisation {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        private static List<Organisation> GetAllOrganisations()
        {
            using (var context = new STUFVModelContext())
            {
                List<Organisation> Organisations = new List<Organisation>();
                Organisations = context.Organisations.ToList();
                return Organisations;
            }
        }
        public static int HasOrganisation(int userId)
        {
            List<Organisation> organisations = GetAllOrganisations();
            int x;
            for (x = 0; x < organisations.Count(); x++)
            {
                if (organisations.ElementAt(x).UserId.Equals(userId) && organisations.ElementAt(x).Active == true)
                {
                    return 2;
                }
                if (organisations.ElementAt(x).UserId.Equals(userId))
                {
                    return 1;
                }
            }
            return 0;
        }
        public static void NewOrganisation(int userId, String name, String disc) {
            var organisation = new Organisation {UserId = userId, Active = false, Name=name, Description=disc };
            using (var context = new STUFVModelContext())
            {
                context.Organisations.Add(organisation);
                context.SaveChanges();
            }
        }
    }
}