﻿using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using tweet_service.Common.Kafka;
using tweet_service.Common.Kafka.Interfaces;
using tweet_service.Data;
using tweet_service.Models;
using tweet_service.Models.Dto;
using tweet_service.Repositories.Interfaces;
using tweet_service.Services;
using tweet_service.Tests.Mock;
using Xunit;

namespace tweet_service.Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        private readonly Mock<IKafkaProducerHandler> _mockKafkaProducer;
        private readonly Mock<ITweetRepository> _mockRepository;
        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _mockRepository = new Mock<ITweetRepository>();
            _mockKafkaProducer = new Mock<IKafkaProducerHandler>();
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<ITweetRepository>(_ => _mockRepository.Object);
                    services.AddSingleton<IKafkaProducerHandler>(_ => _mockKafkaProducer.Object);
                });

            });
            _client = _factory.CreateClient();
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
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
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
