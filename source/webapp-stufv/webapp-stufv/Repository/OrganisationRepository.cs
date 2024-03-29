﻿using System;
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
                if (organisations.ElementAt(x).UserId.Equals(userId) && organisations.ElementAt(x).Active == false && organisations.ElementAt(x).isRegistered == true)
                {
                    return 3;
                }
                if (organisations.ElementAt(x).UserId.Equals(userId) && organisations.ElementAt(x).Active == true && organisations.ElementAt(x).isRegistered == true)
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
            var organisation = new Organisation { UserId = userId, Name = name, Description = disc, Active=false, isRegistered=false };
            using (var context = new STUFVModelContext())
            {
                context.Organisations.Add(organisation);
                context.SaveChanges();
            }
        }
        public string GetOrganisationName(int userId) {
            string name = "";
            List<Organisation> organisations = GetAllOrganisations();
            name = organisations.Single(o => o.UserId == userId && o.Active).Name;
            return name;
        }
        public int GetOrganisationId(int userId)
        {
            int id = 0;
            List<Organisation> organisations = GetAllOrganisations();
            id = organisations.Single(o => o.UserId == userId && o.Active).Id;
            return id;
        }
    }
}