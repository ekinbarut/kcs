using kcs.Blog.Abstraction.CommandResult;

namespace kcs.Blog.Abstraction.Command
{
    public class AddReviewCommand : CommandBase<AddReviewCommandResult>
    {
        public int ArticleId { get; set; }
        public int ReviewerId { get; set; }
        public string Reviewer { get; set; }
        public string ReviewContent { get; set; }
    }
}
