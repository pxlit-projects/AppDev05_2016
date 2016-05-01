using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class NewsController : Controller {
        private IArticleRepository iarticle = new ArticleRepository();
        // GET: News
        public ActionResult Index ( ) {
            ViewBag.Title = "Nieuws";
            return View ( iarticle.getAllArticles ( ) );
        }

        public ActionResult Details ( int id ) {
            Article toFetch = iarticle.getArticle ( id );
            ViewBag.Title = toFetch.Title;
            return View ( toFetch );
        }

        public ActionResult AddThumbsUp ( int id ) {
            iarticle.AddThumbsUp ( id );
            return RedirectToAction("Details", "News", new { id = id });
        }
    }
}