using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class TipRepository : ITipRepository
    {
        public List<Tip> getAllTips()
        {
            using (var context = new STUFVModelContext())
            {
                List<Tip> tips = new List<Tip>();
                tips = context.Tips.ToList();
                return tips;
            }
        }
    }
}