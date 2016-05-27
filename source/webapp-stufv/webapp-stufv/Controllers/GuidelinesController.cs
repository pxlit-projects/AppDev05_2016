using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class GuidelinesController : Controller {

        /*
         * Variables
         */
        private IGuidelineRepository iguideline = new GuidelineRepository();
        
        /*
         * Guidelines/Index
         */
        public ActionResult Index ( ) {
            ViewBag.Title = "Richtlijnen";
            return View ( iguideline.getAllGuideLines() );
        }
    }
}