using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class NewsController : Controller {

        private IArticleRepository _iarticle = new ArticleRepository( );
        private ITipRepository _itips = new TipRepository( );

        /*
         * News/Index
         */
        public ActionResult Index( ) {
            Random rnd = new Random( );

            List<Tip> tips = _itips.GetAllTips( );
            int r = rnd.Next( tips.Count );
            List<Tip> tipsRandom = new List<Tip>( );
            tipsRandom.Add( tips[ r ] );
            ViewBag.Tips = tipsRandom;
            ViewBag.Title = "Nieuws";
            return View( _iarticle.getAllArticles( ) );
        }

        /*
         * News/Details
         */
        public ActionResult Details( int id ) {
            Article toFetch = _iarticle.getArticle( id );
            ViewBag.Date = toFetch.DateTime.ToShortDateString( );
            ViewBag.Title = toFetch.Title;
            return View( toFetch );
        }

        /*
         * News/AddThumbsUp
         */
        public ActionResult AddThumbsUp( int id ) {
            if ( Session[ "email" ] != null ) {
                using ( var context = new STUFVModelContext( ) ) {
                    int userId;
                    Int32.TryParse( Session[ "userId" ].ToString( ), out userId );
                    var vote = context.ArticleVotes.Find( userId, id );

                    if ( vote == null ) {
                        _iarticle.AddThumbsUp( id );
                        var newVote = new ArticleVote( );
                        newVote.UserId = userId;
                        newVote.ArticleId = id;
                        context.ArticleVotes.Add( newVote );
                        context.SaveChanges( );
                    }
                }
            }

            return RedirectToAction( "Details", "News", new {
                id = id
            } );
        }
    }
}