using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class NewsController : Controller {
        // GET: News
        public ActionResult Index ( ) {
            ViewBag.Title = "Nieuws";
            return View ( Article.getAllArticles ( ) );
        }

        public ActionResult Details ( int id ) {
            Article toFetch = Article.getArticle ( id );
            ViewBag.Title = toFetch.Title;
            return View ( toFetch );
        }

        public ActionResult AddThumbsUp ( int id ) {
            Article.AddThumbsUp ( id );
            return RedirectToAction("Details", "News", new { id = id });
        }
    }
}