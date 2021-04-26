using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class DeleteArticleCommandValidator : BaseValidator<DeleteArticleCommand>
    {
        public DeleteArticleCommandValidator()
        {
            RuleFor(x => x.ArticleId).NotEmpty();
        }
    }
}
