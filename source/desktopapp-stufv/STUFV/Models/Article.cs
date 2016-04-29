using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace STUFV {
    public class Article {
        public int Id { get; set; }
        [ForeignKey ( "User" )]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required, MaxLength ( 50 )]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int ThumbsUp { get; set; }
        public Boolean Active { get; set; }

        // Methods
        public static List<Article> getAllArticles ( ) {
            using ( var context = new STUFVModelContext ( ) ) {
                return context.Articles.ToList ( );
            }
        }

        public static Article getArticle ( int id ) {
            using ( var context = new STUFVModelContext ( ) ) {
                return context.Articles.Find ( id );
            }
        }

        public static void AddThumbsUp ( int id ) {
            using ( var context = new STUFVModelContext ( ) ) {
                Article article = context.Articles.Find ( id );
                article.ThumbsUp += 1;
                context.SaveChanges ( );
            }
        }
    }
}