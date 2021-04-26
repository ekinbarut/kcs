using kcs.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Tests.FluentData
{
    public class FluentReview : Review
    {
        protected FluentReview()
        {
        }

        public static FluentReview Init => new FluentReview
        {
        };

        public FluentReview WithData(int id, string title, string reviewer, string content)
        {
            this.ReviewId = id;
            this.ArticleId = id;
            this.Reviewer = reviewer;
            this.ReviewContent = content;

            return this;
        }
    }
}
