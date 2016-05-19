using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers
{
    public class PartnerController : Controller
    {
        private IPartnerRepository ipartner = new PartnerRepository();

        public ActionResult Index()
        {
            List<Partner> partner = ipartner.GetAllPartners();
            ViewBag.Partner = partner;

            return View();
        }
            

    }
}