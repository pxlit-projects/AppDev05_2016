using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IArticleRepository 
    {
        List<Article> getAllArticles();
        Article getArticle(int id);
        void AddThumbsUp(int id);
    }
}