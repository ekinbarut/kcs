using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.CommandResult
{
    public class CreateArticleCommandResult
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ArticleContent { get; set; }
        public DateTime PublishDate { get; set; }
        public short? StarCount { get; set; }
    }
}
