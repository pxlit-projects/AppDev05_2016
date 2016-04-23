using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers
{
    public class EventsController : Controller
    {
        List<Event> _events;
        public ActionResult Index()
        {
            ViewBag.Title = "Evenementen";
            GetEvents();
            var model = from r in _events
                            orderby r.Id
                            select r;
                return View(model);
            }
        public ActionResult Details(int id)
        {
            GetEvents();
            var _event = _events.Single(r => r.Id == id);
            ViewBag.Title = _event.Name;
            return View(_event);
        }
        public ActionResult Attend(int id) {
            if (Session["email"] == null || Session["email"].Equals("")){
                int userid = (int)Session["ID"];
                Attendance at = new Attendance();
                at.Attend(userid, id);
            }
            return View();
        }
        private void GetEvents() {
            using (var context = new STUFVModelContext())
            {
                _events = context.Events.ToList();
            }
        }
    }
}