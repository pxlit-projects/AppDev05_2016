﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class GuidelinesController : Controller {
        // GET: Guidelines
        public ActionResult Index ( ) {
            ViewBag.Title = "Richtlijnen";
            return View ( Guideline.getAllGuideLines() );
        }
    }
}