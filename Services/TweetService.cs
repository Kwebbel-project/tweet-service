using tweet_service.Models;
using tweet_service.Repositories;
using tweet_service.Services.interfaces;

namespace tweet_service.Services
{
    public class TweetService : ITweetService
    {
        private readonly TweetRepository _repository;

        public TweetService(TweetRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Tweet>> GetAllTweets()
        {
            return await _repository.GetAsync();
        }

        public async Task<Tweet> CreateTweet(Tweet newTweet)
        {
            await _repository.CreateAsync(newTweet);
            return newTweet;
        }

    }
}
