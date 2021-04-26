using kcs.Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kcs.Blog.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        IReviewRepository Reviews { get; }
        Task<int> CommitAsync();
    }
}
