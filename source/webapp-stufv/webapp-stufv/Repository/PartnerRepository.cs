using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class PartnerRepository : IPartnerRepository
    {
        public List<Partner> GetAllPartners()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Partners.Where(p=> p.Active).ToList();
            }
        }
    }
}