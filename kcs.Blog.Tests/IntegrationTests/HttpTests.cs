using FluentAssertions;
using kcs.Blog.Abstraction.Command;
using kcs.Blog.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace kcs.Blog.Tests.IntegrationTests
{
    public class HttpTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;
        public HttpTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }


        [Theory]
        [InlineData("/odata")]
        [InlineData("/odata/articles")]
        [InlineData("/odata/reviews")]
        public async Task Get(string url)
        {
            //Arrange
            var client = factory.CreateClient();

            //Act 
            var response = await client.GetAsync(url);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData("api/articles/create")]
        [InlineData("api/articles/update")]
        [InlineData("api/articles/delete")]
        [InlineData("api/reviews/add")]
        [InlineData("api/reviews/update")]
        [InlineData("api/reviews/remove")]
        public async Task Post_ValidationError(string url)
        {
            //Arrange
            var client = factory.CreateClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(new { }), Encoding.UTF8, "application/json");

            //Act 
            var response = await client.PostAsync(url, stringContent);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
