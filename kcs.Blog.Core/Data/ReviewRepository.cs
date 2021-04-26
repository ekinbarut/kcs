using kcs.Blog.Core.Repositories;
using kcs.Blog.Domain.Data;
using kcs.Blog.Domain.Entities;
using kcs.Blog.Infrastructure.Context;

namespace kcs.Blog.Core.Data
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(BlogDbContext context)
            : base(context)
        { }
    }
}
