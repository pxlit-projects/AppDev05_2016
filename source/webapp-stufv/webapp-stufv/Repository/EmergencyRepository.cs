using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class EmergencyRepository : IEmergencyRepository
    {
        public List<Emergency> getAllEmergencies()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Emergencies.ToList();
            }
        }
    }
}