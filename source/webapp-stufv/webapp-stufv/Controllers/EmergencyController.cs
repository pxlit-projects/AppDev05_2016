using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class EmergencyController : Controller {
        // GET: Emergency
        public ActionResult Index ( ) {
            ViewBag.Title = "Noodnummers";
            return View ( Emergency.getAllEmergencies ( ) );
        }
    }
}