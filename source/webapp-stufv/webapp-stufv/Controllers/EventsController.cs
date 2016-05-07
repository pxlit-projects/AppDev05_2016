using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Repository;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class EventsController : Controller {
        private IEventRepository ievent = new EventRepository ( );
        private IAttendanceRepository iattend = new AttendanceRepository ( );
        private IDesDriverRepository idesdriver = new DesDriverRepository ( );
        private IPassengerRepository ipassenger = new PassengerRepository ( );


        List<Event> _events;
        public ActionResult Index ( ) {
            ViewBag.Title = "Evenementen";
            _events = ievent.GetAllEvents ( );
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
                if ( ipassenger.IsPassenger ( id, userId ) ) {
                    ViewBag.isPassenger = true;
                } else {
                    ViewBag.isPassenger = false;
                }
            }
            _events = ievent.GetAllEvents ( );
            var tuple = new Tuple<Event, DesDriver, string> ( _events.Single ( r => r.Id == id ), new DesDriver ( ), new EventRepository ( ).getCity ( _events.Single ( r => r.Id == id ).ZipCode ) );
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
            return View ( );
        }
        public ActionResult BobProcess ( int id ) {
            int NrOfPlaces;
            int.TryParse ( Request.Form[ "Item2.NrOfPlaces" ], out NrOfPlaces );
            ViewBag.id = id;
            idesdriver.SetDES ( ( int ) Session[ "userId" ], id, NrOfPlaces );
            return View ( );
        }
        public ActionResult RemoveBob ( int id ) {
            ViewBag.id = id;
            idesdriver.unSetDES ( ( int ) Session[ "userId" ], id );
            return View ( );
        }
        public ActionResult FindBob ( int id ) {
            ViewBag.Title = "Find bob";
            ViewBag.Description = "Heb je al een bob? Kijk hieronder en vind een bob of schijf jezelf in als bob.";
            return View ( idesdriver.ActiveDriversPerEvent ( id, ( int ) Session[ "userId" ] ) );
        }
        public ActionResult JoinBob ( int id ) {
            ViewBag.Title = "Find bob";
            if ( ipassenger.IsPassenger ( id, ( int ) Session[ "userId" ] ) ) {
                ViewBag.Title = "Je hebt je al voor deze bob ingeschreven.";
            } else {
                ipassenger.NewPassenger ( ( int ) Session[ "userId" ], id );
            }

            return View ( );
        }

        public ActionResult AlcohoLFree ( string value ) {
            using ( var context = new STUFVModelContext ( ) ) {
                IEnumerable<Event> events;

                if ( value.Equals ( "yes" ) ) {
                    events = context.Events.Where ( e => e.AlcoholFree == true ).ToList ( );
                } else if ( value.Equals ( "no" ) ) {
                    events = context.Events.Where ( e => e.AlcoholFree == false ).ToList ( );
                } else {
                    events = context.Events.ToList ( );
                }

                ViewBag.Title = "Evenementen";

                return View ( "~/Views/Events/Index.cshtml", events );
            }
        }

        public ActionResult Sort ( string value ) {
            using ( var context = new STUFVModelContext ( ) ) {
                IEnumerable<Event> events;
                IEnumerable<Event> model;

                events = context.Events.ToList ( );

                if ( value.Equals ( "atoz" ) ) {
                    model = from r in events
                            orderby r.Name
                            select r;
                } else if ( value.Equals ( "ztoa" ) ) {
                    model = from r in events
                            orderby r.Name descending
                            select r;
                } else if ( value.Equals ( "entranceasc" ) ) {
                    model = from r in events
                            orderby r.EntranceFee
                            select r;
                } else {
                    model = from r in events
                            orderby r.EntranceFee descending
                            select r;
                }

                ViewBag.Title = "Evenementen";

                return View ( "~/Views/Events/Index.cshtml", model );
            }
        }

        public ActionResult filterZipCode () {
            using ( var context = new STUFVModelContext ( ) ) {
                var zipCode = Request.Form[ "Zipcode" ];
                var events = context.Events.Where ( e => e.ZipCode == zipCode ).ToList ( );

                ViewBag.Title = "Evenementen";

                return View ( "~/Views/Events/Index.cshtml", events );
            }
        }

        public ActionResult filterName ( ) {
            using ( var context = new STUFVModelContext ( ) ) {
                var name = Request.Form[ "Name" ];
                var events = context.Events.Where ( e => e.Name.Contains( name )).ToList ( );

                ViewBag.Title = "Evenementen";

                return View ( "~/Views/Events/Index.cshtml", events );
            }
        }

        public ActionResult AddReview (int id) {
            string comment = Request.Form[ "Comment" ];

            using ( var context = new STUFVModelContext ( ) ) {
                var review = new Review ( );
                review.Active = true;
                review.DateTime = System.DateTime.Now;
                review.EventId = id;
                int userId;
                Int32.TryParse(Session[ "userId" ].ToString(), out userId);
                review.UserId = userId;
                review.Flagged = false;
                review.Content = comment;
                context.Reviews.Add ( review );
                context.SaveChanges ( );
            }

            return View ( "~/Views/Events/Details/" + id + ".cshtml");
        }
    }
}