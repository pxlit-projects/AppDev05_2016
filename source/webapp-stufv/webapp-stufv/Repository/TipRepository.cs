using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class TipRepository : ITipRepository
    {
        public List<Tip> GetAllTips()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Tips.ToList();
            }
        }
    }
}