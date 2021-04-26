using kcs.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Tests.FluentData
{
    public class FluentArticle : Article
    {
        protected FluentArticle()
        {
        }

        public static FluentArticle Init => new FluentArticle
        {
        };

        public FluentArticle WithData(int id, string title, string author, string content, DateTime publishdate, short starCount)
        {
            this.ArticleId = id;
            this.Title = title;
            this.Author = author;
            this.ArticleContent = content;
            this.PublishDate = publishdate;
            this.StarCount = starCount;

            return this;
        }
    }
}
