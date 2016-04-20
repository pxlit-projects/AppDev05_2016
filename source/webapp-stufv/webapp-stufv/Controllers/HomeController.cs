﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class HomeController : Controller {
        static List<Article> _articles = new List<Article>
        {
            new Article
            {
                Id = 1,
                UserId = 1,
                CampaignId = 1,
                Title = "First Title",
                Content = "First article, this article is about the first article ever made on the best website of the world. You will remember this first ever article on the best website of the world until the end of your days.",
                DateTime = System.DateTime.Now,
                Rating = 10,
                Active = true
            }
        };

        static List<Event> _events = new List<Event>
        {
            new Event
            {
                Id = 1,
                OrganisationId = 1,
                Name = "First event",
                Description = "Beerfest",
                Type = "Beer",
                ZipCode = "3500",
                Start 
            }
        }

        public ActionResult Index ( ) {

            return View ( _articles );
        }
    }
}
