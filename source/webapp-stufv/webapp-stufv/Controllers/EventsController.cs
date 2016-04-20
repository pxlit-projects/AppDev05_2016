using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp_stufv.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Evenementen";
            var model = from r in _events
                        orderby r.Id
                        select r;
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var _event = _events.Single(r => r.Id == id);
            ViewBag.Title = _event.Name;
            return View(_event);
        }

        static List<Models.Event> _events = new List<Models.Event>
        {
            new Models.Event {
                Id=1, Name="Kevin zijn verjaardag", OrganisationId=1, Description="kevin is jarig en hij wilt graag een feestje maar van mama mag er geen alcohol zijn",
                Type=1, Street="kevinzijnhuis 50", ZipCode="420", Start=new DateTime(2016,04,20,13,0,0,0), End=new DateTime(2016,04,20,14,0,0,0), EntranceFee=0, AlcoholFree=true, Active=true
            },
            new Models.Event {
<<<<<<< HEAD:source/webapp-stufv/webapp-stufv/Controllers/EventController.cs
                Id=1, Name="sacha gaat naar het gekkenhuis", OrganisationId=1, Description="we zijn blij dat hij eindelijk weg is",
                Type=1, Street="kevinzijnhuis 50", ZipCode="420", Start=new DateTime(2016,04,20,13,0,0,0), End=new DateTime(2016,04,20,13,0,0,0), EntranceFee=0, AlcoholFree=false, Active=true
=======
                Id=2, Name="sacha gaat naar het gekkenhuis", OrganisationId=1, Description="we zijn blij dat hij eindelijk weg is",
                Type="1", Street="kevinzijnhuis 50", ZipCode="420", Start=new DateTime(2016,04,20,13,0,0,0), End=new DateTime(2016,04,20,13,0,0,0), EntranceFee=0, AlcoholFree=false, Active=true
>>>>>>> dc185d7d33333bd2d7331607ed0c2d8043caa3af:source/webapp-stufv/webapp-stufv/Controllers/EventsController.cs
            }
        };
    }
}