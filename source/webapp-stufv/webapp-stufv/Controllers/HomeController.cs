using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class HomeController : Controller {

        private IEventRepository ievent = new EventRepository ( );
        private IArticleRepository iarticle = new ArticleRepository ( );

        public ActionResult Index ( ) {
            ViewBag.Articles = iarticle.getAllArticles ( );
            ViewBag.Events = ievent.GetAllEvents ( );
            return View ( );
        }
    }
}
