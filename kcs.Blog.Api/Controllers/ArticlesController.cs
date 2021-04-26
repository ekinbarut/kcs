using kcs.Blog.Domain.Entities;
using kcs.Blog.Infrastructure.Context;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace kcs.Blog.Api.Controllers
{
    [Authorize]
    public class ArticlesController : ODataController
    {
        private readonly BlogDbContext ctx;

        public ArticlesController(BlogDbContext ctx)
        {
            this.ctx = ctx;
        }

        [EnableQuery]
        public SingleResult<Article> Get(int key)
        {
            return new SingleResult<Article>(ctx.Articles.Where(v => v.ArticleId == key));
        }

        [EnableQuery]
        public IQueryable<Article> Get()
        {
            return ctx.Articles;
        }
    }
}
