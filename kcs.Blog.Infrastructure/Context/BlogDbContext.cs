using kcs.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace kcs.Blog.Infrastructure.Context
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        public BlogDbContext() : base() { }
        public BlogDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>().HasMany(a => a.Reviews).WithOne(s => s.Article);
            base.OnModelCreating(builder);
        }
    }
}
