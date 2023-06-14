using tweet_service.Models;
using tweet_service.Repositories.Interfaces;

namespace tweet_service.Tests.Mock
{
    public class MockRepository : ITweetRepository
    {
        public Task CreateTweet(Tweet newTweet)
        {
            return Task.FromResult(true);
        }

        public Task DeleteTweet(string id)
        {
            return Task.FromResult(true);
        }

        public Task<List<Tweet>> GetAllTweets()
        {
            throw new NotImplementedException();
        }

        public Task<Tweet> GetTweetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTweet(string id, Tweet updatedTweet)
        {
            return Task.FromResult(true);
        }
    }
}
