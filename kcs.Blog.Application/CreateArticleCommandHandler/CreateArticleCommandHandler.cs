using kcs.Blog.Domain.Entities;
//using kcs.Blog.Abstraction.Command;
using System;
using System.Threading;
using System.Threading.Tasks;
using kcs.Blog.Abstraction.CommandResult;
using kcs.Blog.Core.Data;
using kcs.Blog.Abstraction.Command;
using MediatR;

namespace kcs.Blog.Application.CreateArticleCommandHandler
{
    public class CreateArticleComandHandler : IRequestHandler<CreateArticleCommand, CreateArticleCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateArticleComandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CreateArticleCommandResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new Article();
            DateTime.TryParse(request.PublishDate, out DateTime date);
            article.Create(request.Title, request.Author, request.ArticleContent, date, request.StarCount);

            await this.unitOfWork.Articles.AddAsync(article).ConfigureAwait(false);

            return new CreateArticleCommandResult() { ArticleContent = request.ArticleContent, Author = request.Author, PublishDate = DateTime.Parse(request.PublishDate), StarCount = request.StarCount, Title = request.Title };
        }
    }
}
