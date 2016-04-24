using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class HomeController : Controller {
        public ActionResult Index ( ) {
            ViewBag.Articles = Article.getAllArticles();
            ViewBag.Events = Event.GetAllEvents();
            return View();
        }
    }
}
