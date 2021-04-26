using kcs.Blog.Domain.Entities;
using MediatR;
using kcs.Blog.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using kcs.Blog.Infrastructure.Context;
using kcs.Blog.Abstraction.CommandResult;
using kcs.Blog.Core.Data;
using kcs.Blog.Abstraction.Validator;
using FluentValidation;

namespace kcs.Blog.Application.AddReviewCommandHandler
{
    public class AddReviewCommandHandler : ICommandHandler<AddReviewCommand, AddReviewCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AddReviewCommandResult> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review();
            review.Add(request.ArticleId, request.Reviewer, request.ReviewContent);

            await this.unitOfWork.Reviews.AddAsync(review).ConfigureAwait(false);

            return new AddReviewCommandResult();
        }
    }
}
