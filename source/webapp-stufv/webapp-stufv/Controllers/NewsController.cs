using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class NewsController : Controller {
        private IArticleRepository iarticle = new ArticleRepository ( );
        // GET: News
        public ActionResult Index ( ) {
            ViewBag.Title = "Nieuws";
            return View ( iarticle.getAllArticles ( ) );
        }

        public ActionResult Details ( int id ) {
            Article toFetch = iarticle.getArticle ( id );
            ViewBag.Date = toFetch.DateTime.ToShortDateString ( );
            ViewBag.Title = toFetch.Title;
            return View ( toFetch );
        }

        public ActionResult AddThumbsUp ( int id ) {
            if ( Session["userId"] != null && !Session[ "userId" ].Equals("") ) {
                using ( var context = new STUFVModelContext ( ) ) {
                    int userId;
                    Int32.TryParse ( Session[ "userId" ].ToString ( ), out userId );
                    var vote = context.ArticleVotes.Find ( userId, id );

                    if ( vote == null ) {
                        iarticle.AddThumbsUp ( id );
                        var newVote = new ArticleVote ( );
                        newVote.UserId = userId;
                        newVote.ArticleId = id;
                        context.ArticleVotes.Add ( newVote );
                        context.SaveChanges ( );
                    }
                }
            }
            
            return RedirectToAction ( "Details", "News", new {
                id = id
            } );
        }
    }
}