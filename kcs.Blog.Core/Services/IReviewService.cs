using kcs.Blog.Domain.Entities;
using System.Threading.Tasks;

namespace kcs.Blog.Core.Services
{
    public interface IReviewService
    {
        Task<Review> GetReviewById(int id);
        Task<Review> CreateReview(Review newReview);
        Task UpdateReview(Review review, Review newReview);
        Task DeleteReview(Review Review);
    }
}
