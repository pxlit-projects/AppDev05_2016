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
            _events = Event.GetAllEvents();
            var model = from r in _events
                            orderby r.Id
                            select r;
                return View(model);
            }
        public ActionResult Details(int id)
        {
            if (Session["email"] == null || Session["email"].Equals(""))
            { }
            else {
                if (Attendance.IsAttending((int)Session["userId"], id))
                {
                    ViewBag.attend = true;
                }
                else {
                    ViewBag.attend = false;
                }
            }
            _events = Event.GetAllEvents();
            var _event = _events.Single(r => r.Id == id);
            ViewBag.Title = _event.Name;
            return View(_event);
        }
        public ActionResult Attend(int id) {
            ViewBag.Title = "Attend";
            if (Session["email"] == null || Session["email"].Equals(""))
            {
                ViewBag.MyMessageToUsers = "Voor deze functie moet u inloggen.";
                return View();
            }
            else {
                int userid = (int)Session["userId"];
                try { Attendance.SignAttend(userid, id); }
                catch(System.Data.Entity.Infrastructure.DbUpdateException e) {
                    ViewBag.MyMessageToUsers = "Je hebt je al aangemeld voor dit evenement";
                    return View();
                }
                
                ViewBag.MyMessageToUsers = "U bent aangemeld voor dit evenement";
                return View();
            }
        }
        public ActionResult RemoveAttend(int id)
        {
            //remove attendance
            return View();
        }
    }
}