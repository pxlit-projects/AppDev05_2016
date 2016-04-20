using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp_stufv.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Aanmelden";
            return View();
        }

        public ActionResult Verwerk()
        {
            return View();
        }
    }
}