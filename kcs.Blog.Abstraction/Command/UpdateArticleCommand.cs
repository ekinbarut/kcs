using kcs.Blog.Abstraction.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.Command
{
    public class UpdateArticleCommand : CommandBase<UpdateArticleCommandResult>
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ArticleContent { get; set; }
        public string PublishDate { get; set; }
        public short? StarCount { get; set; }

    }
}
