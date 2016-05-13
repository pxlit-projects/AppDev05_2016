﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class OrganisationController : Controller {

        private IOrganisationRepository iorganisation = new OrganisationRepository ( );

        // GET: Organisation

        public ActionResult Index ( ) {
            ViewBag.Title = "Organisatie";
            if ( ( int ) Session[ "organisation" ] == 1 ) {
                ViewBag.Description = "Uw organisatie is nog niet geactiveerd.";
            } else if ( ( int ) Session[ "organisation" ] == 2 ) {
                ViewBag.Description = "";
                ViewBag.Title = "Organisatie: " + iorganisation.GetOrganisationName ( ( int ) Session[ "userId" ] );
                using ( var context = new STUFVModelContext ( ) ) {
                    int userId = Convert.ToInt32 ( Session[ "userId" ] );
                    var organisations = context.Organisations.Where ( o => o.UserId == userId ).ToList ( );
                    var organisation = organisations.ElementAt ( 0 );
                    var eventTypes = context.EventTypes.ToList();
                    var events = context.Events.Where ( e => e.OrganisationId == organisation.Id ).ToList ( );
                    var tuple = new Tuple<IEnumerable<Event>, Organisation,IEnumerable<EventTypes>> ( events, organisation, eventTypes );
                    return View ( tuple );
                }
            } else if ( ( int ) Session[ "organisation" ] == 3 ) {
                ViewBag.Description = "Uw organisatie is geblokeerd.";
            } else {
                ViewBag.Description = "U heeft geen organisatie geregistreerd.";
            }

            return View ( new Tuple<IEnumerable<Event>, Organisation> ( null, null ) );
        }

        public ActionResult Register ( ) {
            return View ( );
        }

        public ActionResult Process ( ) {
            ViewBag.Title = "Registratie organisatie";
            ViewBag.Description = "U registratie is gelukt. U organisatie zal binnenkort geactiveerd worden.";
            String name = Request.Form[ "Name" ];
            String description = Request.Form[ "Description" ];
            iorganisation.NewOrganisation ( ( int ) Session[ "userId" ], name, description );
            Session[ "organisation" ] = 1;
            return View ( );
        }

        public ActionResult NewEvent ( HttpPostedFileBase file ) {
            string filename = "noimageavailable.png";
            Boolean alcoholFree = false;
            if ( file != null ) {
                EventImgUpload ( file );
                filename = file.FileName;
            }
            if (Request.Form["AlcoholFree"] != null) {
                alcoholFree = true;
            }
            DateTime start = DateTime.Parse ( Request.Form[ "Start" ] );
            DateTime end = DateTime.Parse ( Request.Form[ "End" ] );
            var newEvent = new Event {
                Name = Request.Form[ "Name" ],
                Description = Request.Form[ "Description" ],
                Start = start,
                End = end,
                Street = Request.Form[ "Street" ],
                ZipCode = Request.Form[ "ZipCode" ],
                Type = int.Parse ( Request.Form[ "Type" ] ),
                EntranceFee = double.Parse ( Request.Form[ "EntranceFee" ] ),
                AlcoholFree = alcoholFree,
                OrganisationId = iorganisation.GetOrganisationId ( ( int ) Session[ "userId" ] ),
                Active = false,
                Image = filename
            };
            using ( var context = new STUFVModelContext ( ) ) {
                context.Events.Add ( newEvent );
                context.SaveChanges ( );
            }
            Index();
            return View (@"~\Views\Organisation\Index.cshtml");
        }

        private void EventImgUpload ( HttpPostedFileBase file ) {
            string pic = System.IO.Path.GetFileName ( file.FileName );
            string path = System.IO.Path.Combine (
                                   Server.MapPath ( @"..\Content\img\EventImages\" ), pic );
            // file is uploaded
            file.SaveAs ( path );
            int userId = ( int ) Session[ "userId" ];
            using ( var context = new STUFVModelContext ( ) ) {
                var user = context.Users.FirstOrDefault ( c => c.Id == userId );
                user.ProfilePicture = file.FileName;
                context.SaveChanges ( );
            }
        }
    }
}