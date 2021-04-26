using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class AddReviewCommandValidator : BaseValidator<AddReviewCommand>
    {
        public AddReviewCommandValidator()
        {
            RuleFor(x => x.ArticleId).NotEmpty();
            RuleFor(x => x.Reviewer).NotEmpty();
            RuleFor(x => x.ReviewContent).NotEmpty();
        }
    }
}
