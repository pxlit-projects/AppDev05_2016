using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp_stufv.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Evenementen";

            return View();
        }
    }
}