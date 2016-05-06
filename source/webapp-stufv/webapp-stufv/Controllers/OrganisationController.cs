﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class OrganisationController : Controller {

        private IOrganisationRepository iorganisation = new OrganisationRepository();
        
        // GET: Organisation

        public ActionResult Index ( ) {
            ViewBag.Title = "Organisatie";
            if ((int)Session["organisation"] == 1)
            {
                ViewBag.Description = "U organisatie is nog niet geactiveerd.";
            }
            else if ((int)Session["organisation"] == 2)
            {
                ViewBag.Description = "";
                ViewBag.Title = "Organisatie: " + iorganisation.GetOrganisationName((int)Session["userId"]);
            }
            else {
                ViewBag.Description = "U heeft geen organisatie.";
            }
            return View ( );
        }

        public ActionResult Register ( ) {
            return View ( );
        }
        public ActionResult Process()
        {
            ViewBag.Title = "Registratie organisatie";
            ViewBag.Description = "U registratie is gelukt. U organisatie zal binnenkort geactiveerd worden.";
            String name = Request.Form["Name"];
            String description = Request.Form["Description"];
            iorganisation.NewOrganisation((int)Session["userId"], name, description);
            Session["organisation"] = 1;
            return View();
        }
        public ActionResult NewEvent()
        {
            DateTime start = DateTime.Parse(Request.Form["Start"]);
            DateTime end = DateTime.Parse(Request.Form["End"]);
            var newEvent = new Event
            {
                Name = Request.Form["Name"],
                Description = Request.Form["Description"],
                Start = start,
                End = end,
                Street = Request.Form["Street"],
                ZipCode = Request.Form["ZipCode"],
                Type = int.Parse(Request.Form["Type"]),
                EntranceFee = double.Parse(Request.Form["EntranceFee"]),
                AlcoholFree = Boolean.Parse(Request.Form["AlcoholFree"]),
                OrganisationId = iorganisation.GetOrganisationId((int)Session["userId"]),
                Active = false
            };
            using (var context = new STUFVModelContext())
            {
                context.Events.Add(newEvent);
                context.SaveChanges();
            }
            return View();
        }
    }
}