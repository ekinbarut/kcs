using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class CreateArticleCommandValidator : BaseValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ArticleContent).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(X => X.PublishDate).NotNull().NotEmpty();
            RuleFor(x => x.StarCount).NotEmpty();
        }
    }
}
