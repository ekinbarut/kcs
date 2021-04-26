using kcs.Blog.Abstraction.CommandResult;

namespace kcs.Blog.Abstraction.Command
{
    public class CreateArticleCommand : CommandBase<CreateArticleCommandResult>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ArticleContent { get; set; }
        public string PublishDate { get; set; }
        public short? StarCount { get; set; }
    }
}
