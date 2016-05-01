using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        public List<Organisation> GetAllOrganisations()
        {
            using (var context = new STUFVModelContext())
            {
                List<Organisation> Organisations = new List<Organisation>();
                Organisations = context.Organisations.ToList();
                return Organisations;
            }
        }

        public int HasOrganisation(int userId)
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

        public void NewOrganisation(int userId, string name, string disc)
        {
            var organisation = new Organisation { UserId = userId, Active = false, Name = name, Description = disc };
            using (var context = new STUFVModelContext())
            {
                context.Organisations.Add(organisation);
                context.SaveChanges();
            }
        }
    }
}