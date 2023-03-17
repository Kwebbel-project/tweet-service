using tweet_service.Models;
using tweet_service.Repositories;

namespace tweet_service.Services
{
    public class TweetService
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

        public async Task<Tweet> CreateTweets(Tweet newTweet)
        {
            await _repository.CreateAsync(newTweet);
            return newTweet;
        }

    }
}
