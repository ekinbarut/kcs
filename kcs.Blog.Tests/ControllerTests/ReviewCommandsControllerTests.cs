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
    public class ReviewCommandsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyReviews_ReturnsEmptyResponse()
        {
            // Arrange


            // Act
            var response = await TestClient.GetAsync("odata/reviews");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<OData<FluentReview>>()).Value.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsReview_WhenReviewExistsInTheDatabase()
        {
            //Arrange
            var review = FluentReview.Init.WithData(1, "Test Title", "Reviewer", "ReviewContent");
            var article = FluentArticle.Init.WithData(1, "Test Title", "Author", "ArticleContent", DateTime.Now.Date, 5);
            var articleRequest = new CreateArticleCommand { ArticleContent = article.ArticleContent, Author = article.Author, PublishDate = article.PublishDate.ToString(), StarCount = article.StarCount, Title = article.Title };
            await CreateArticleAsync(articleRequest);

            var reviewRequest = new AddReviewCommand { ArticleId = article.ArticleId, ReviewContent = review.ReviewContent, Reviewer = review.Reviewer};
            await AddReviewAsync(reviewRequest);

            // Act
            var response = await TestClient.GetAsync("odata/reviews");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var createdReview = await response.Content.ReadAsAsync<OData<FluentReview>>();
            createdReview.Value.FirstOrDefault(c => c.ReviewContent == review.ReviewContent).Should().NotBeNull().And.BeEquivalentTo(review);
        }
    }
}
