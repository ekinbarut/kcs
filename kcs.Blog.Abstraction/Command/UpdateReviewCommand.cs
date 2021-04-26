using kcs.Blog.Abstraction.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kcs.Blog.Abstraction.Command
{
    public class UpdateReviewCommand : CommandBase<UpdateReviewCommandResult>
    {
        public int ReviewId { get; set; }
        public string ReviewContent { get; set; }
        public string Reviewer { get; set; }
    }
}
