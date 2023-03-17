using tweet_service.Models;

namespace tweet_service.Services.interfaces
{
    public interface ITweetService
    {
        public Task<List<Tweet>> GetAllTweets();
        public Task<Tweet> CreateTweet(Tweet newTweet);
    }
}
