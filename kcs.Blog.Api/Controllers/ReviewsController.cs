using kcs.Blog.Domain.Entities;
using kcs.Blog.Infrastructure.Context;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcs.Blog.Api.Controllers
{
    [Authorize]
    public class ReviewsController : ODataController
    {
        private readonly BlogDbContext ctx;

        public ReviewsController(BlogDbContext ctx)
        {
            this.ctx = ctx;
        }

        [EnableQuery]
        public SingleResult<Review> Get(int key)
        {
            return new SingleResult<Review>(ctx.Reviews.Where(v => v.ReviewId == key));
        }

        [EnableQuery]
        public IQueryable<Review> Get()
        {
            return ctx.Reviews;
        }
    }
}
