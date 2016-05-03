using System.Collections.Generic;
using System.Linq;

namespace STUFV.Repository
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