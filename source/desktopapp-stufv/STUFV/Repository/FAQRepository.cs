using System.Collections.Generic;
using System.Linq;

namespace STUFV.Repository
{
    public class FAQRepository : IFAQRepository
    {
        public List<FAQ> getAllFAQ()
        {
            using (var context = new STUFVModelContext())
            {
                return context.FAQs.ToList();
            }
        }
    }
}