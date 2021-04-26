using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Domain.Entities
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ArticleContent { get; set; }
        public DateTime PublishDate { get; set; }
        public short? StarCount { get; set; }

        #region [ Navigation Properties ]

        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        #endregion

        public void Create(string title, string author, string articleContent, DateTime publishDate, short? starCount)
        {
            this.Title = title;
            this.Author = author;
            this.ArticleContent = articleContent;
            this.PublishDate = publishDate;
            this.StarCount = starCount;
        }

        public void Update(int id, string title, string author, string articleContent, DateTime publishDate, short? starCount)
        {
            this.ArticleId = id;
            this.Title = title;
            this.Author = author;
            this.ArticleContent = articleContent;
            this.PublishDate = publishDate;
            this.StarCount = starCount;
        }
    }
}
