using kcs.Blog.Abstraction.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.Command
{
    public class DeleteArticleCommand : CommandBase<DeleteArticleCommandResult>
    {
        public int ArticleId { get; set; }
    }
}
