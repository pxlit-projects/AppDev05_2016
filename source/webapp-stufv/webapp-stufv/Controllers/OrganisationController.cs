using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp_stufv.Controllers {
    public class OrganisationController : Controller {
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
            Models.Organisation.NewOrganisation((int)Session["userId"], name, description);
            Session["organisation"] = 1;
            return View();
        }
    }
}