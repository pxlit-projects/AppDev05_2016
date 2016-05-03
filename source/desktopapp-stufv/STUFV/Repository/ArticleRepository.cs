using System.Collections.Generic;
using System.Linq;

namespace STUFV.Repository
{
    public class ArticleRepository : IArticleRepository
    {


        public List<Article> getAllArticles()
        {
            using (var context = new STUFVModelContext())
            {
                return context.Articles.ToList();
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