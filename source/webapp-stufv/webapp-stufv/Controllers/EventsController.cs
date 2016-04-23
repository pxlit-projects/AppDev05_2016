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
                Id=2, Name="sacha gaat naar het gekkenhuis", OrganisationId=1, Description="we zijn blij dat hij eindelijk weg is",
                Type=1, Street="kevinzijnhuis 50", ZipCode="420", Start=new DateTime(2016,04,20,13,0,0,0), End=new DateTime(2016,04,20,13,0,0,0), EntranceFee=0, AlcoholFree=false, Active=true,
            },
            new Models.Event {
                Id=3, Name="Piepschuim", OrganisationId=1, Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec.",
                Type=1, Street="kevinzijnhuis 50", ZipCode="420", Start=new DateTime(2016,04,20,13,0,0,0), End=new DateTime(2016,04,20,13,0,0,0), EntranceFee=0, AlcoholFree=false, Active=true,
            }
        };
    }
}