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
            var organisation = new Organisation { UserId = userId, Name = name, Description = disc };
            using (var context = new STUFVModelContext())
            {
                context.Organisations.Add(organisation);
                context.SaveChanges();
            }
        }
        public string GetOrganisationName(int userId) {
            string name = "";
            List<Organisation> organisations = GetAllOrganisations();
            int x;
            for (x = 0; x < organisations.Count(); x++)
            {
                if (organisations.ElementAt(x).UserId.Equals(userId) && organisations.ElementAt(x).Active == true)
                {
                    name = organisations.ElementAt(x).Name;
                }
            }
            return name;
        }
        public int GetOrganisationId(int userId)
        {
            int id = 0;
            List<Organisation> organisations = GetAllOrganisations();
            int x;
            for (x = 0; x < organisations.Count(); x++)
            {
                if (organisations.ElementAt(x).UserId.Equals(userId) && organisations.ElementAt(x).Active == true)
                {
                    id = organisations.ElementAt(x).Id;
                }
            }
            return id;
        }
    }
}