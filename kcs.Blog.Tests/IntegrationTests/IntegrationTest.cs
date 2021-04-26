using kcs.Blog.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using kcs.Blog.Infrastructure.Context;
using System.Linq;
using kcs.Blog.Abstraction.Command;
using MediatR;
using MediatR.Pipeline;
using kcs.Blog.Application;
using kcs.Blog.Tests.FluentData;
using Microsoft.Extensions.Options;

namespace kcs.Blog.Tests.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        //BlogDbContext ctx;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BlogDbContext>));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }
                        services.AddDbContext<BlogDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                        services.RegisterRequestHandlers();
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task CreateArticleAsync(CreateArticleCommand request)
        {
            await TestClient.PostAsJsonAsync("api/articles/create", request);
        }

        protected async Task AddReviewAsync(AddReviewCommand request)
        {
            await TestClient.PostAsJsonAsync("api/reviews/add", request);
        }
    }
}
