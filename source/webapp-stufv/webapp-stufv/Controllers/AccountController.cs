using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class AccountController : Controller {
        // GET: Account
        public ActionResult Login ( ) {
            ViewBag.Title = "Login";
            return View ( );
        }
        public ActionResult Register ( ) {
            ViewBag.Title = "Registratie";
            return View ( );
        }
        public ActionResult Process ( ) {
            var email = Request.Form[ "Email" ];
            var password = Request.Form[ "Password" ];

            if ( webapp_stufv.Models.User.login ( email, password ) ) {
                Session[ "email" ] = email;
                ViewBag.Title = "Succes";
                return View ( );
            } else {
                ViewBag.Title = "Login mislukt";
                Session[ "email" ] = "";
                return View ( );
            }
        }
        public ActionResult Logout ( ) {
            Session[ "Email" ] = "";
            ViewBag.Title = "Logout gelukt";
            return View ( );
        }

        public ActionResult CreateAccount ( ) {
            User newUser = new User ( );
            newUser.Active = true;
            newUser.Email = Request.Form[ "email" ];
            ViewBag.Title = "Registratie";
            return View (newUser );
        }
    }
}