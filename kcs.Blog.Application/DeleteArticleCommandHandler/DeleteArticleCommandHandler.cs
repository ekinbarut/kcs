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

namespace kcs.Blog.Application.DeleteArticleCommandHandler
{
    public class DeleteArticleComandHandler : ICommandHandler<DeleteArticleCommand, DeleteArticleCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteArticleComandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<DeleteArticleCommandResult> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await this.unitOfWork.Articles.SingleOrDefaultAsync(r => r.ArticleId == request.ArticleId);

            if (article == null)
            {
                throw new Exception();
            }

            this.unitOfWork.Articles.Remove(article);

            return new DeleteArticleCommandResult();
        }
    }
}
