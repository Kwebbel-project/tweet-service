namespace tweet_service.tests;

using Moq;
using System.Text.Json;
using tweet_service.Common.Kafka;
using tweet_service.Common.Kafka.Interfaces;
using tweet_service.Models;
using tweet_service.Repositories.Interfaces;
using tweet_service.Services;
using tweet_service.Services.interfaces;

public class TweetServiceTests
{
        private readonly Mock<ITweetRepository> _mockRepository;
        private readonly Mock<IKafkaProducerHandler> _mockKafkaProducer;
        private readonly ITweetService _tweetService;
        private Tweet newTweet;
        public TweetServiceTests()
        {
            _mockRepository = new Mock<ITweetRepository>();
            _mockKafkaProducer = new Mock<IKafkaProducerHandler>();
            _tweetService = new TweetService(_mockRepository.Object, _mockKafkaProducer.Object);
            newTweet = new Tweet { Content = "test123", Author = "Test Author", CreatedAt = DateTime.Now, userId = 1};
        }
        [Fact]
        public async Task CreateTweet_Should_Call_Repository_And_KafkaProducer()
        {
            // Act
        await _tweetService.CreateTweet(newTweet);
        var jsonOptions = new JsonSerializerOptions();
        // Assert
        _mockRepository.Verify(r => r.CreateTweet(newTweet), Times.Once);
        _mockKafkaProducer.Verify(k => k.sendMessage(Topics.TWEET_CREATED,
            System.Text.Json.JsonSerializer.Serialize(newTweet, jsonOptions)), Times.Once);
    }
    [Fact]
    public async Task CreateTweet_Should_Return_New_Tweet()
    {
        // Act
        var result = await _tweetService.CreateTweet(newTweet);
        // Assert
        Assert.Equal(newTweet, result);
    }
}