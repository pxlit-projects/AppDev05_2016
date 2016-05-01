using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class GuidelineRepository : IGuidelineRepository
    {
        public List<Guideline> getAllGuideLines()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Guidelines.ToList();
            }
        }
    }
}