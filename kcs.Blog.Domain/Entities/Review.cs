using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Domain.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int ArticleId { get; set; }
        public string Reviewer { get; set; }
        public string ReviewContent { get; set; }

        #region [ Navigation Properties ] 

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        #endregion

        public void Add(int articleId, string reviewer, string reviewContent)
        {
            this.ArticleId = articleId;
            this.Reviewer = reviewer;
            this.ReviewContent = reviewContent;
        }

        public void Update(int reviewId, string reviewer, string reviewContent)
        {
            this.ReviewId = reviewId;
            this.Reviewer = reviewer;
            this.ReviewContent = reviewContent;
        }
    }
}
