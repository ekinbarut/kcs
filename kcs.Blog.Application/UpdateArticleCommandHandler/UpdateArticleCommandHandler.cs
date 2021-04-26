using kcs.Blog.Abstraction.Command;
using System.Threading;
using System.Threading.Tasks;
using kcs.Blog.Abstraction.CommandResult;
using kcs.Blog.Core.Data;
using System;

namespace kcs.Blog.Application.UpdateArticleCommandHandler
{
    public class UpdateReviewCommandHandler : ICommandHandler<UpdateArticleCommand, UpdateArticleCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateArticleCommandResult> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await this.unitOfWork.Articles.SingleOrDefaultAsync(c => c.ArticleId == request.ArticleId);

            if (article == null)
            {
                throw new Exception();
            }

            DateTime.TryParse(request.PublishDate, out DateTime date);
            article.Update(request.ArticleId, request.Title, request.Author, request.ArticleContent, date, request.StarCount);

            await this.unitOfWork.Articles.AddAsync(article).ConfigureAwait(false);

            return new UpdateArticleCommandResult() { ArticleId = request.ArticleId };
        }
    }
}
