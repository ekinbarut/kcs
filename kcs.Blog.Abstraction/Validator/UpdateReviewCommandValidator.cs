using FluentValidation;
using kcs.Blog.Abstraction.Command;

namespace kcs.Blog.Abstraction.Validator
{
    public class UpdateReviewCommandValidator : BaseValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(x => x.ReviewId).NotEmpty();
            RuleFor(x => x.Reviewer).NotEmpty();
            RuleFor(x => x.ReviewContent).NotEmpty();
        }
    }
}
