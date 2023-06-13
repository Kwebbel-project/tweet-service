using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using tweet_service.Models;
using tweet_service.Models.Dto;
using Xunit;

namespace tweet_service.Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetTweets_ReturnsOkResponse()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/tweet");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateTweet_ReturnsCreatedTweet()
        {
            // Arrange
            var newTweet = new TweetCreateDto { Content = "Integration test", Author = "Test User", userId = 9999 };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/tweet");
            request.Content = new StringContent(JsonConvert.SerializeObject(newTweet), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.SendAsync(request);
            var createdTweet = await response.Content.ReadFromJsonAsync<Tweet>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(newTweet.Content, createdTweet.Content);
            Assert.Equal(newTweet.Author, createdTweet.Author);
            Assert.Equal(newTweet.userId, createdTweet.userId);
        }
    }
}
