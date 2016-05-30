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
        private ITipRepository itips = new TipRepository ( );
        private Random rnd = new Random();

        public ActionResult Index ( ) {

            List<Article> articleList = iarticle.getAllArticles ( );
            List<Article> articleLast4 = new List<Article>();
            int articleCount = articleList.Count;
            for (int i = articleCount - 1; i > articleCount - 5; i--)
            {
                articleLast4.Add(articleList.ElementAt(i));
            }
            ViewBag.Articles = articleLast4;

            /*List<Event> eventList = ievent.GetAllUnexpiredEvents();
            List<Event> eventLast4 = new List<Event>();
            int eventCount = eventList.Count;
            for (int i = eventCount - 1; i > eventCount - 5; i--)
            {
                eventLast4.Add(eventList.ElementAt(i));
            }
            ViewBag.Events = eventLast4;*/

            List<Event> eventList = ievent.GetAllUnexpiredEventsByDate();
            ViewBag.Events = eventList;


            List<Tip> tips = itips.GetAllTips();
            int r = rnd.Next(tips.Count);
            List<Tip> tipsRandom = new List<Tip>();
            tipsRandom.Add(tips[r]);
            ViewBag.Tips = tipsRandom;
            return View ( );
        }
    }
}
