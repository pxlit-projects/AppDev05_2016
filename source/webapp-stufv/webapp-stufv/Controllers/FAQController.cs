using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers
{
    public class FAQController : Controller
    {
        public ActionResult Index()
        { 

            FAQ fq = new FAQ();
            FAQ fq_2 = new FAQ();

            fq.Id = 1;
            fq.Question = "How do I login?";
            fq.Answer = "Just do it.";
            fq_2.Id = 2;
            fq_2.Question = "Are you sure?";
            fq_2.Answer = "Yes I am";
            List<FAQ> _fqs = new List<FAQ>();
            _fqs.Add(fq);
            _fqs.Add(fq_2);
            ViewBag.Title = "Frequente vragen";

            return View(_fqs);
        }
    }
}