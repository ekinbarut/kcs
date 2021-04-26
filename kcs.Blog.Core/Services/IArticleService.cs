using kcs.Blog.Domain.Entities;
using System.Threading.Tasks;

namespace kcs.Blog.Core.Services
{
    public interface IArticleService
    {
        Task<Article> GetArticleById(int id);
        Task<Article> CreateArticle(Article newArticle);
        Task UpdateArticle(Article article, Article newArticle);
        Task DeleteArticle(Article Article);
    }
}
