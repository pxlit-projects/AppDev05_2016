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
            List<Article> articleList = iarticle.getAllArticles ( );
            List<Article> articleLast3 = new List<Article>();
            int articleCount = articleList.Count;
            for (int i = articleCount-1; i > articleCount-4; i--)
            {
                articleLast3.Add(articleList.ElementAt(i));
            }
            ViewBag.Articles = articleLast3;
          
            List<Event> eventList = ievent.GetAllEvents();
            List<Event> eventLast3 = new List<Event>();
            int eventCount = eventList.Count;
            for (int i = eventCount - 1; i > eventCount - 4; i--)
            {
                eventLast3.Add(eventList.ElementAt(i));
            }
            ViewBag.Events = eventLast3;
            return View ( );
        }
    }
}
