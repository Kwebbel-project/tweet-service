using tweet_service.Common.Kafka;
using tweet_service.Common.Kafka.Interfaces;
using tweet_service.Models;
using tweet_service.Repositories.Interfaces;
using tweet_service.Services.interfaces;

namespace tweet_service.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _repository;
        private readonly IKafkaProducerHandler _kafkaProducerHandler;

        public TweetService(ITweetRepository repository, IKafkaProducerHandler kafkaProducerHandler)
        {
            _repository = repository;
            _kafkaProducerHandler = kafkaProducerHandler;
        }

        public async Task<List<Tweet>> GetAllTweets()
        {
            return await _repository.GetAllTweets();
        }

        public async Task<Tweet> CreateTweet(Tweet newTweet)
        {
            try
            {
                await _repository.CreateTweet(newTweet);

                await _kafkaProducerHandler.sendMessage(Topics.TWEET_CREATED, System.Text.Json.JsonSerializer.Serialize(newTweet));

                return newTweet;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
