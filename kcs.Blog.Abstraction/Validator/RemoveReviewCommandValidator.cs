using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class RemoveReviewCommandValidator : BaseValidator<RemoveReviewCommand>
    {
        public RemoveReviewCommandValidator()
        {
            RuleFor(x => x.ReviewId).NotEmpty();
        }
    }
}
