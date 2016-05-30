using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Repository;
using webapp_stufv.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace webapp_stufv.Controllers
{
    public class EventsController : Controller
    {

        /*
         * Variables
         */
        private IEventRepository ievent = new EventRepository();
        private IAttendanceRepository iattend = new AttendanceRepository();
        private IDesDriverRepository idesdriver = new DesDriverRepository();
        private IPassengerRepository ipassenger = new PassengerRepository();
        private List<Event> _events;

        /*
         * Events/Index
         */
        public ActionResult Index()
        {
            ViewBag.Title = "Evenementen";
            _events = ievent.GetAllUnexpiredEvents();

            var model = from r in _events
                        orderby r.Id
                        select r;

            return View(model);
        }

        /*
         * Events/Details
         */
        public ActionResult Details(int id)
        {
            if (Session["email"] == null || Session["email"].Equals("")) { }
            else {
                int userId = (int)Session["userId"];
                if (iattend.IsAttending(userId, id))
                {
                    ViewBag.attend = true;
                }
                else {
                    ViewBag.attend = false;
                }
                if (idesdriver.IsDES(userId, id))
                {
                    ViewBag.isBob = true;
                }
                else {
                    ViewBag.isBob = false;
                }
            }
            _events = ievent.GetAllEvents();
            IEnumerable<Review> reviews;
            using (var context = new STUFVModelContext())
            {
                reviews = context.Reviews.Include("User").Where(r => r.EventId == id).ToList();
            }
            var tuple = new Tuple<Event, DesDriver, string, IEnumerable<Review>>(_events.Single(r => r.Id == id), new DesDriver(), new EventRepository().getCity(_events.Single(r => r.Id == id).ZipCode), reviews);
            ViewBag.Title = tuple.Item1.Name;
            return View(tuple);
        }

        /*
         * Events/Attend
         */
        public ActionResult Attend(int id)
        {
            if (CanAccess())
            {
                ViewBag.Title = "Attend";
                ViewBag.id = id;
                if (Session["email"] == null || Session["email"].Equals(""))
                {
                    ViewBag.MyMessageToUsers = "Voor deze functie moet u inloggen.";
                    return View();
                }
                else {
                    int userid = (int)Session["userId"];
                    try { iattend.SignAttend(userid, id); }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        ViewBag.MyMessageToUsers = "Je hebt je al aangemeld voor dit evenement";
                        return View();
                    }

                    ViewBag.MyMessageToUsers = "U bent aangemeld voor dit evenement";
                    return View();
                }
            }
            return RedirectToAction("Details", "Events", new { id = id });
        }

        /*
         * Events/RemoveAttend
         */
        public ActionResult RemoveAttend(int id)
        {
            if (CanAccess())
            {
                iattend.UnSignAttend((int)Session["userId"], id);
                ViewBag.id = id;
                return RedirectToAction("Details", "Events", new { id = id });
            }
            return RedirectToAction("Details", "Events", new { id = id });
        }

        // FILTER
        /*
         * Events/AlcoholFree
         */
        public ActionResult AlcohoLFree(string value)
        {
            Session["AlcoholFree"] = value;
            return RedirectToAction("Index", "Events");
        }

        /*
         * Events/Sort
         */
        public ActionResult Sort(string value)
        {
            Session["Sort"] = value;
            return RedirectToAction("Index", "Events");
        }

        /*
         * Events/filterZipCode
         */
        public IEnumerable<Event> filterZipCode(IEnumerable<Event> events, string zip)
        {
            if (!zip.Equals(""))
            {
                return events.Where(e => e.ZipCode.Contains(zip)).ToList();
            }
            else {
                return events;
            }
        }

        /*
         * Events/filterName
         */
        public IEnumerable<Event> filterName(IEnumerable<Event> events, string needle)
        {
            if (!needle.Equals(""))
            {
                return events.Where(e => e.Name.Contains(needle)).ToList();
            }
            else {
                return events;
            }
        }

        /*
         * Events/filter
         */
        public ActionResult filter()
        {
            using (var context = new STUFVModelContext())
            {
                IEnumerable<Event> events = context.Events.ToList();
                DateTime date;

                if (Session["AlcoholFree"] != null)
                {
                    events = filterAlcohol(events, Session["AlcoholFree"].ToString());
                }

                if (Session["Sort"] != null)
                {
                    events = filterSort(events, Session["Sort"].ToString());
                }
                events = filterName(events, Request.Form["Name"]);
                events = filterZipCode(events, Request.Form["ZipCode"]);
                if (Request.Form["Date"] != "")
                {
                    date = DateTime.Parse(Request.Form["Date"]);
                    events = filterDate(events, date);
                }


                ViewBag.Title = "Evenementen";

                return View("~/Views/Events/Index.cshtml", events);
            }
        }

        /*
         * Function to search events at the specified date after submitting the filter
         */
        private IEnumerable<Event> filterDate(IEnumerable<Event> events, DateTime date)
        {
            events = events.Where(e => e.Start.ToShortDateString() == date.ToShortDateString()).ToList();
            return events;
        }

        /*
         * Function to execute the specified sorting after submitting the filter
         */
        private IEnumerable<Event> filterSort(IEnumerable<Event> events, string value)
        {
            if (value.Equals("atoz"))
            {
                events = from r in events
                         orderby r.Name
                         select r;
            }
            else if (value.Equals("ztoa"))
            {
                events = from r in events
                         orderby r.Name descending
                         select r;
            }
            else if (value.Equals("entranceasc"))
            {
                events = from r in events
                         orderby r.EntranceFee
                         select r;
            }
            else {
                events = from r in events
                         orderby r.EntranceFee descending
                         select r;
            }

            return events;
        }

        /*
         * Events/filterAlcohol
         */
        public IEnumerable<Event> filterAlcohol(IEnumerable<Event> events, string value)
        {
            if (value.Equals("yes"))
            {
                events = events.Where(e => e.AlcoholFree == true).ToList();
            }
            else if (value.Equals("no"))
            {
                events = events.Where(e => e.AlcoholFree == false).ToList();
            }
            else {
                return events;
            }

            return events;
        }



        // REVIEWS
        /*
         * Events/AddReview
         */
        public ActionResult AddReview(int id)
        {
            if (CanAccess())
            {
                string comment = Request.Form["Comment"];
                int eventid = id;

                using (var context = new STUFVModelContext())
                {
                    var review = new Review();
                    review.Active = true;
                    review.DateTime = System.DateTime.Now;
                    review.EventId = id;
                    int userId;
                    Int32.TryParse(Session["userId"].ToString(), out userId);
                    review.UserId = userId;
                    review.Flagged = false;
                    review.Content = comment;
                    review.Status = "okay";
                    context.Reviews.Add(review);
                    context.SaveChanges();
                }

                return RedirectToAction("Details", "Events", new { id = eventid });
            }
            return RedirectToAction("Details", "Events", new { id = id });
        }

        /*
         * Events/FlagReaction
         */
        public ActionResult FlagReaction(int id)
        {
            CanAccess();
            using (var context = new STUFVModelContext())
            {
                Review review = context.Reviews.Find(id);
                review.Flagged = true;
                context.SaveChanges();

                ViewBag.Title = "Reactie gemeld";
                return View(review);
            }
        }

        /*
         * Events/DeleteReaction
         */
        public ActionResult DeleteReaction(int id, int eventId)
        {
            if (CanAccess())
            {
                using (var context = new STUFVModelContext())
                {
                    Review review = context.Reviews.Find(id);
                    context.Reviews.Remove(review);
                    context.SaveChanges();

                    return RedirectToAction("Details", "Events", new { id = eventId });
                }
            }
            else {
                return RedirectToAction("Details", "Events", new { id = eventId });
            }
        }

        // BOB
        /*
        * Events/BobProcess
        */
        public ActionResult BobProcess(int id)
        {
            if (CanAccess())
            {
                int NrOfPlaces;
                int.TryParse(Request.Form["Item2.NrOfPlaces"], out NrOfPlaces);
                ViewBag.id = id;
                idesdriver.SetDES((int)Session["userId"], id, NrOfPlaces);
                return RedirectToAction("Details", "Events", new { id = id });
            }
            return RedirectToAction("Details", "Events", new { id = id });
        }

        /*
         * Events/RemoveBob
         */
        public ActionResult RemoveBob(int id)
        {
            if (CanAccess())
            {
                ViewBag.id = id;
                idesdriver.unSetDES((int)Session["userId"], id);
                using (var context = new STUFVModelContext())
                {
                    DesDriver driver = context.DesDrivers.Single(e => e.UserId == (int)Session["userId"] && e.EventId == id);
                    List<Passenger> passengers = context.Passengers.Where(e => e.DesDriverId == driver.Id).ToList();
                    for (int i = 0; i < passengers.Count(); i++)
                    {
                        passengers.ElementAt(i).Active = false;
                    }
                    context.SaveChanges();
                }
                return RedirectToAction("Details", "Events", new { id = id });
            }
            return RedirectToAction("Index", "Events");
        }

        /*
         * Events/FindBob
         */
        public ActionResult FindBob(int id)
        {
            if (CanAccess())
            {
                ViewBag.Title = "Find bob";
                ViewBag.EventId = id;
                ViewBag.Description = "Heb je al een bob? Kijk hieronder en vind een bob of schijf jezelf in als bob.";
                return View(idesdriver.ActiveDriversPerEvent(id, (int)Session["userId"]));
            }
            return RedirectToAction("Index", "Events");
        }

        /*
         * Events/JoinBob
         */
        public ActionResult JoinBob(int id)
        {
            if (CanAccess())
            {
                ViewBag.Title = "Find bob";
                int eventId = 0;
                if (ipassenger.IsPassenger(id, (int)Session["userId"], out eventId))
                {
                    ViewBag.Title = "Je bent al geacepteerd door een bob.";
                }
                else {
                    ipassenger.NewPassenger((int)Session["userId"], id, out eventId);
                }
                return RedirectToAction("Details", "Events", new { id = eventId });
            }
            return RedirectToAction("Index", "Events");
        }

        /*
         * Events/BobSettings
         */
        public ActionResult BobSettings(int id)
        {
            if (CanAccess())
            {
                ViewBag.Title = "BOB instelligen";
                ViewBag.EventId = id;
                List<DesDriver> drivers = idesdriver.GetAllDrivers();
                int userId = (int)Session["userId"];
                DesDriver driver = drivers.Single(e => e.UserId == userId && e.EventId == id);
                List<Passenger> passengers = ipassenger.GetAllPassengers();
                List<Passenger> acceptedPassengers = passengers.Where(e => e.DesDriverId == driver.Id && e.Accepted && e.Active).ToList();
                List<Passenger> notAcceptedPassengers = passengers.Where(e => e.DesDriverId == driver.Id && !e.Accepted && e.Active).ToList();
                var tuple = new Tuple<IEnumerable<Passenger>, IEnumerable<Passenger>>(acceptedPassengers, notAcceptedPassengers);
                return View(tuple);
            }
            else {
                return RedirectToAction("Index", "Events");
            }
        }

        /*
         * Events/AcceptPas
         */
        public ActionResult AcceptPas(int pasId, int eventId)
        {
            if (CanAccess())
            {
                using (var context = new STUFVModelContext())
                {
                    Passenger passenger = context.Passengers.Single(e => e.Id == pasId);
                    passenger.Accepted = true;
                    context.SaveChanges();
                }
                return RedirectToAction("BobSettings", "Events", new { id = eventId });
            }
            else {
                return RedirectToAction("Index", "Events");
            }
        }

        /*
         * Events/RemovePas
         */
        public ActionResult RemovePas(int pasId, int eventId)
        {
            if (CanAccess())
            {
                using (var context = new STUFVModelContext())
                {
                    Passenger passenger = context.Passengers.Single(e => e.Id == pasId);
                    passenger.Accepted = false;
                    context.SaveChanges();
                }
                return RedirectToAction("BobSettings", "Events", new { id = eventId });
            }
            else {
                return RedirectToAction("Index", "Events");
            }
        }
        private Boolean CanAccess()
        {
            Boolean canAccess = true;
            if (Session["email"] == null)
            {
                RedirectToAction("Home", "index");
                canAccess = false;
            }
            return canAccess;
        }
    }
}