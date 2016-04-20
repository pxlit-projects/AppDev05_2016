using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class GuidelinesController : Controller {
        // GET: Guidelines
        public ActionResult Index ( ) {
            Guideline gl = new Guideline ( );
            Guideline gl_2 = new Guideline ( );
            gl.Id = 1;
            gl.Short = "Don't drink too much.";
            gl.Content = "If you drink too much, you will die.";
            gl_2.Id = 2;
            gl_2.Short = "Don't drink whiskey.";
            gl_2.Content = "seriously, you'll die.";
            List<Guideline> _gls = new List<Guideline> ( );
            _gls.Add ( gl );
            _gls.Add ( gl_2 );
            ViewBag.Title = "Richtlijnen";
            return View ( _gls );
        }
    }
}