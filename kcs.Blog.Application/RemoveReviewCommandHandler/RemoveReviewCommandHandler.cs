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

namespace kcs.Blog.Application.RemoveReviewCommandHandler
{
    public class RemoveReviewComandHandler : ICommandHandler<RemoveReviewCommand, RemoveReviewCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveReviewComandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<RemoveReviewCommandResult> Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await this.unitOfWork.Reviews.SingleOrDefaultAsync(r => r.ReviewId == request.ReviewId);

            if (review == null)
            {
                throw new Exception();
            }

            this.unitOfWork.Reviews.Remove(review);

            return new RemoveReviewCommandResult() { };
        }
    }
}
