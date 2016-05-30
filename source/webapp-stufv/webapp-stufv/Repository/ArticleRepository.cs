using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class ArticleRepository : IArticleRepository
    {


        public List<Article> getAllArticles()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Articles.Where(a => a.Active == true ).ToList();
            }
        }

        public Article getArticle(int id)
        {
            using (var context = new STUFVModelContext())
            {
                return context.Articles.Find(id);
            }
        }

        public void AddThumbsUp(int id)
        {
            using (var context = new STUFVModelContext())
            {
                Article article = context.Articles.Find(id);
                article.ThumbsUp += 1;
                context.SaveChanges();
            }
        }

    }
}