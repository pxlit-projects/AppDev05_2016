using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class FAQRepository : IFAQRepository
    {
        public List<FAQ> getAllFAQ()
        {
            using (var context = new STUFVModelContext())
            {
                return context.FAQs.Where(e=> e.Active).ToList();
            }
        }
    }
}