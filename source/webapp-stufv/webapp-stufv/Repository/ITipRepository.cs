using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public interface ITipRepository
    {
        List<Tip> GetAllTips();
    }
}