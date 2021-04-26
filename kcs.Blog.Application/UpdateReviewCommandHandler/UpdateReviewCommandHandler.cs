using kcs.Blog.Abstraction.Command;
using System.Threading;
using System.Threading.Tasks;
using kcs.Blog.Abstraction.CommandResult;
using kcs.Blog.Core.Data;

namespace kcs.Blog.Application.UpdateReviewCommandHandler
{
    public class UpdateReviewCommandHandler : ICommandHandler<UpdateReviewCommand, UpdateReviewCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateReviewCommandResult> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await this.unitOfWork.Reviews.SingleOrDefaultAsync(c => c.ReviewId == request.ReviewId);

            if(review == null)
            {
                throw new System.Exception();
            }

            review.Update(request.ReviewId, request.Reviewer, request.ReviewContent);

            await this.unitOfWork.Reviews.AddAsync(review).ConfigureAwait(false);

            return new UpdateReviewCommandResult() { };
        }
    }
}
