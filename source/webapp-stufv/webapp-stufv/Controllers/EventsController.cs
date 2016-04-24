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
                if (DesDriver.IsDES((int)Session["userId"], id))
                {
                    ViewBag.isBob = true;
                }
                else {
                    ViewBag.isBob = false;
                }
            }
            _events = Event.GetAllEvents();
            var tuple = new Tuple<Event, DesDriver>(_events.Single(r => r.Id == id), new DesDriver());
            ViewBag.Title = tuple.Item1.Name;
            return View(tuple);
        }
        public ActionResult Attend(int id) {
            ViewBag.Title = "Attend";
            ViewBag.id = id;
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
            Attendance.UnSignAttend((int)Session["userId"], id);
            ViewBag.id = id;
            return View();
        }
        public ActionResult BobProcess(int id) {
            int NrOfPlaces;
            int.TryParse(Request.Form["NrOfPlaces"], out NrOfPlaces);
            ViewBag.id = id;
            DesDriver.SetDES((int)Session["userId"], id, NrOfPlaces);
            return View();
        }
        public ActionResult RemoveBob(int id) {
            ViewBag.id = id;
            DesDriver.unSetDES((int)Session["userId"], id);
            return View();
        }
        public ActionResult FindBob(int id) {
            ViewBag.Title = "Find bob";
            return View(DesDriver.ActiveDriversPerEvent(id));
        }
    }
}