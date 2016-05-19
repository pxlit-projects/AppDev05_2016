using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Repository;
using webapp_stufv.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace webapp_stufv.Controllers {
    public class EventsController : Controller {
        private IEventRepository ievent = new EventRepository ( );
        private IAttendanceRepository iattend = new AttendanceRepository ( );
        private IDesDriverRepository idesdriver = new DesDriverRepository ( );
        private IPassengerRepository ipassenger = new PassengerRepository ( );


        List<Event> _events;
        public ActionResult Index ( ) {
            ViewBag.Title = "Evenementen";
            _events = ievent.GetAllUnexpiredEvents ( );
            var model = from r in _events
                        orderby r.Id
                        select r;
            return View ( model );
        }

        public ActionResult Details ( int id ) {
            if ( Session[ "email" ] == null || Session[ "email" ].Equals ( "" ) ) { } else {
                int userId = ( int ) Session[ "userId" ];
                if ( iattend.IsAttending ( userId, id ) ) {
                    ViewBag.attend = true;
                } else {
                    ViewBag.attend = false;
                }
                if ( idesdriver.IsDES ( userId, id ) ) {
                    ViewBag.isBob = true;
                } else {
                    ViewBag.isBob = false;
                }
            }
            _events = ievent.GetAllEvents ( );
            IEnumerable<Review> reviews;
            using ( var context = new STUFVModelContext ( ) ) {
                reviews = context.Reviews.Include ( "User" ).Where ( r => r.EventId == id ).ToList ( );
            }
            var tuple = new Tuple<Event, DesDriver, string, IEnumerable<Review>> ( _events.Single ( r => r.Id == id ), new DesDriver ( ), new EventRepository ( ).getCity ( _events.Single ( r => r.Id == id ).ZipCode ), reviews );
            ViewBag.Title = tuple.Item1.Name;
            return View ( tuple );
        }
        public ActionResult Attend ( int id ) {
            ViewBag.Title = "Attend";
            ViewBag.id = id;
            if ( Session[ "email" ] == null || Session[ "email" ].Equals ( "" ) ) {
                ViewBag.MyMessageToUsers = "Voor deze functie moet u inloggen.";
                return View ( );
            } else {
                int userid = ( int ) Session[ "userId" ];
                try { iattend.SignAttend ( userid, id ); } catch ( System.Data.Entity.Infrastructure.DbUpdateException e ) {
                    ViewBag.MyMessageToUsers = "Je hebt je al aangemeld voor dit evenement";
                    return View ( );
                }

                ViewBag.MyMessageToUsers = "U bent aangemeld voor dit evenement";
                return View ( );
            }
        }
        public ActionResult RemoveAttend ( int id ) {
            iattend.UnSignAttend ( ( int ) Session[ "userId" ], id );
            ViewBag.id = id;
            return RedirectToAction ( "Details", "Events", new { id = id } );
        }
        public ActionResult BobProcess ( int id ) {
            int NrOfPlaces;
            int.TryParse ( Request.Form[ "Item2.NrOfPlaces" ], out NrOfPlaces );
            ViewBag.id = id;
            idesdriver.SetDES ( ( int ) Session[ "userId" ], id, NrOfPlaces );
            return RedirectToAction ( "Details", "Events", new { id = id } );
        }
        public ActionResult RemoveBob ( int id ) {
            ViewBag.id = id;
            idesdriver.unSetDES ( ( int ) Session[ "userId" ], id );
            using ( var context = new STUFVModelContext ( ) ) {
                DesDriver driver = context.DesDrivers.Single ( e => e.UserId == ( int ) Session[ "userId" ] && e.EventId == id );
                List<Passenger> passengers = context.Passengers.Where ( e => e.DesDriverId == driver.Id ).ToList ( );
                for ( int i = 0 ; i < passengers.Count ( ) ; i++ ) {
                    passengers.ElementAt ( i ).Active = false;
                }
                context.SaveChanges ( );
            }
            return RedirectToAction ( "Details", "Events", new { id = id } );
        }
        public ActionResult FindBob ( int id ) {
            ViewBag.Title = "Find bob";
            ViewBag.EventId = id;
            ViewBag.Description = "Heb je al een bob? Kijk hieronder en vind een bob of schijf jezelf in als bob.";
            return View ( idesdriver.ActiveDriversPerEvent ( id, ( int ) Session[ "userId" ] ) );
        }
        public ActionResult JoinBob ( int id ) {
            ViewBag.Title = "Find bob";
            int eventId = 0;
            if ( ipassenger.IsPassenger ( id, ( int ) Session[ "userId" ], out eventId ) ) {
                ViewBag.Title = "Je bent al geacepteerd door een bob.";
            } else {
                ipassenger.NewPassenger ( ( int ) Session[ "userId" ], id, out eventId );
            }
            return RedirectToAction ( "Details", "Events", new { id = eventId } );
        }
        public ActionResult BobSettings ( int id ) {
            ViewBag.Title = "BOB instelligen";
            ViewBag.EventId = id;
            List<DesDriver> drivers = idesdriver.GetAllDrivers ( );
            int userId = ( int ) Session[ "userId" ];
            DesDriver driver = drivers.Single ( e => e.UserId == userId && e.EventId == id );
            List<Passenger> passengers = ipassenger.GetAllPassengers ( );
            List<Passenger> acceptedPassengers = passengers.Where ( e => e.DesDriverId == driver.Id && e.Accepted && e.Active ).ToList ( );
            List<Passenger> notAcceptedPassengers = passengers.Where ( e => e.DesDriverId == driver.Id && !e.Accepted && e.Active ).ToList ( );
            var tuple = new Tuple<IEnumerable<Passenger>, IEnumerable<Passenger>> ( acceptedPassengers, notAcceptedPassengers );
            return View ( tuple );
        }

        public ActionResult AlcohoLFree ( string value ) {
            Session[ "AlcoholFree" ] = value;
            return RedirectToAction ( "Index", "Events" );
        }

        public ActionResult Sort ( string value ) {
            Session[ "Sort" ] = value;
            return RedirectToAction ( "Index", "Events" );
        }

        public IEnumerable<Event> filterZipCode ( IEnumerable<Event> events, string zip ) {
            if ( !zip.Equals ( "" ) ) {
                return events.Where ( e => e.ZipCode.Contains ( zip ) ).ToList ( );
            } else {
                return events;
            }
        }

        public IEnumerable<Event> filterName ( IEnumerable<Event> events, string needle ) {
            if ( !needle.Equals ( "" ) ) {
                return events.Where ( e => e.Name.Contains ( needle ) ).ToList ( );
            } else {
                return events;
            }
        }

        public ActionResult AddReview ( int id ) {
            string comment = Request.Form[ "Comment" ];
            int eventid = id;

            using ( var context = new STUFVModelContext ( ) ) {
                var review = new Review ( );
                review.Active = true;
                review.DateTime = System.DateTime.Now;
                review.EventId = id;
                int userId;
                Int32.TryParse ( Session[ "userId" ].ToString ( ), out userId );
                review.UserId = userId;
                review.Flagged = false;
                review.Content = comment;
                review.Status = "okay";
                context.Reviews.Add ( review );
                context.SaveChanges ( );
            }

            return RedirectToAction ( "Details", "Events", new { id = eventid } );
        }

        public ActionResult FlagReaction ( int id ) {
            using ( var context = new STUFVModelContext ( ) ) {
                Review review = context.Reviews.Find ( id );
                review.Flagged = true;
                context.SaveChanges ( );

                ViewBag.Title = "Reactie gemeld";
                return View ( review );
            }
        }

        public ActionResult DeleteReaction ( int id, int eventId ) {
            using ( var context = new STUFVModelContext ( ) ) {
                Review review = context.Reviews.Find ( id );
                context.Reviews.Remove ( review );
                context.SaveChanges ( );

                return RedirectToAction ( "Details", "Events", new { id = eventId } );
            }
        }
        public ActionResult AcceptPas ( int pasId, int eventId ) {
            using ( var context = new STUFVModelContext ( ) ) {
                Passenger passenger = context.Passengers.Single ( e => e.Id == pasId );
                passenger.Accepted = true;
                context.SaveChanges ( );
            }
            return RedirectToAction ( "BobSettings", "Events", new { id = eventId } );
        }
        public ActionResult RemovePas ( int pasId, int eventId ) {
            using ( var context = new STUFVModelContext ( ) ) {
                Passenger passenger = context.Passengers.Single ( e => e.Id == pasId );
                passenger.Accepted = false;
                context.SaveChanges ( );
            }
            return RedirectToAction ( "BobSettings", "Events", new { id = eventId } );
        }

        public ActionResult filter ( ) {
            using ( var context = new STUFVModelContext ( ) ) {
                IEnumerable<Event> events = context.Events.ToList ( );
                DateTime date;

                if ( Session[ "AlcoholFree" ] != null ) {
                    events = filterAlcohol ( events, Session[ "AlcoholFree" ].ToString ( ) );
                }

                if ( Session[ "Sort" ] != null ) {
                    events = filterSort ( events, Session[ "Sort" ].ToString ( ) );
                }
                events = filterName ( events, Request.Form[ "Name" ] );
                events = filterZipCode ( events, Request.Form[ "ZipCode" ] );
                if (Request.Form["Date"] != "")
                {
                    date = DateTime.Parse(Request.Form["Date"]);
                    events = filterDate(events, date);
                }
                

                ViewBag.Title = "Evenementen";

                return View ( "~/Views/Events/Index.cshtml", events );
            }
        }

        private IEnumerable<Event> filterDate ( IEnumerable<Event> events, DateTime date ) {
            events = events.Where ( e => e.Start.ToShortDateString ( ) == date.ToShortDateString ( ) ).ToList ( );
            return events;
        }

        private IEnumerable<Event> filterSort ( IEnumerable<Event> events, string value ) {
            if ( value.Equals ( "atoz" ) ) {
                events = from r in events
                         orderby r.Name
                         select r;
            } else if ( value.Equals ( "ztoa" ) ) {
                events = from r in events
                         orderby r.Name descending
                         select r;
            } else if ( value.Equals ( "entranceasc" ) ) {
                events = from r in events
                         orderby r.EntranceFee
                         select r;
            } else {
                events = from r in events
                         orderby r.EntranceFee descending
                         select r;
            }

            return events;
        }

        public IEnumerable<Event> filterAlcohol ( IEnumerable<Event> events, string value ) {
            if ( value.Equals ( "yes" ) ) {
                events = events.Where ( e => e.AlcoholFree == true ).ToList ( );
            } else if ( value.Equals ( "no" ) ) {
                events = events.Where ( e => e.AlcoholFree == false ).ToList ( );
            } else {
                return events;
            }

            return events;
        }
    }
}