﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class FAQController : Controller  {

        /*
         * Variables
         */
        private IFAQRepository ifaq = new FAQRepository();

        /*
         * FAQ/Index
         */
        public ActionResult Index ( ) {
            ViewBag.Title = "Veelgestelde vragen";
            return View ( ifaq.getAllFAQ ( ) );
           
        }
    }
}