using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class FAQController : Controller {
        public ActionResult Index ( ) {
            ViewBag.Title = "FAQ";
            return View ( FAQ.getAllFAQ ( ) );
        }
    }
}