using System.Collections.Generic;
using System.Linq;

namespace STUFV.Repository
{
    public class GuidelineRepository : IGuidelineRepository
    {
        public List<Guideline> getAllGuideLines()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Guidelines.Where ( g => g.active == true ).ToList ( );
            }
        }
    }
}