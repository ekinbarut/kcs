using FluentAssertions;
using kcs.Blog.Abstraction.Command;
using kcs.Blog.Domain.Entities;
using kcs.Blog.Tests.FluentData;
using kcs.Blog.Tests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace kcs.Blog.Tests.ControllerTests
{
    public class ArticleCommandsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyArticles_ReturnsEmptyResponse()
        {
            // Arrange


            // Act
            var response = await TestClient.GetAsync("odata/articles");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<OData<FluentArticle>>()).Value.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsArticle_WhenArticleExistsInTheDatabase()
        {
            //Arrange
            var article = FluentArticle.Init.WithData(1, "Test Title", "Author", "ArticleContent", DateTime.Now.Date, 5);
            var request = new CreateArticleCommand { ArticleContent = article.ArticleContent, Author = article.Author, PublishDate = article.PublishDate.ToString(), StarCount = article.StarCount, Title = article.Title };
            await CreateArticleAsync(request);

            // Act
            var response = await TestClient.GetAsync("odata/articles");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var createdArticle = await response.Content.ReadAsAsync<OData<FluentArticle>>();
            createdArticle.Value.FirstOrDefault(c => c.Title == article.Title).Should().NotBeNull().And.BeEquivalentTo(article);
        }
    }
}
