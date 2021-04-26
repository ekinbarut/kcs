using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class UpdateArticleCommandValidator : BaseValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.ArticleId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ArticleContent).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(X => X.PublishDate).NotEmpty();
            RuleFor(x => x.StarCount).NotEmpty();
        }
    }
}
