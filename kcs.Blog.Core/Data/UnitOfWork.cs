using kcs.Blog.Core.Data;
using kcs.Blog.Core.Repositories;
using kcs.Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kcs.Blog.Core.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext context;
        private ArticleRepository articleRepository;
        private ReviewRepository reviewRepository;

        public UnitOfWork(BlogDbContext context)
        {
            this.context = context;
        }

        public IArticleRepository Articles => articleRepository = articleRepository ?? new ArticleRepository(context);

        public IReviewRepository Reviews => reviewRepository = reviewRepository ?? new ReviewRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
