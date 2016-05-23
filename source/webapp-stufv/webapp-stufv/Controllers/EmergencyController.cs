using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {   
    public class EmergencyController : Controller {

        private IEmergencyRepository _iemer = new EmergencyRepository();

        /*
         * Emergency/Index
         */
        public ActionResult Index ( ) {
            ViewBag.Title = "Noodnummers";
            return View ( _iemer.getAllEmergencies ( ) );
        }
    }
}