using System.Threading;
using System.Threading.Tasks;
using kcs.Blog.Core.Data;
using MediatR.Pipeline;

namespace kcs.Blog.Application.RequestPostProcessor
{
    public class RequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public RequestPostProcessor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            await this.unitOfWork.CommitAsync();
        }
    }
}
