using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            using (var db = new STUFVModelContext())
            {
                db.Users.ToList();
            }


            ViewBag.Title = "Aanmelden";
            return View();
        }

        public ActionResult Process()
        {
            string vUsername = Request["vUsername"];
            string vPassword = Request["vPassword"];
            ViewBag.username = vUsername;
            ViewBag.password = vPassword;
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Account aanmaken";
            return View();
        }
    }
}