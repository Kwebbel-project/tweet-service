using tweet_service.Models;

namespace tweet_service.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        public Task<List<Tweet>> GetAllTweets();
        public Task<Tweet> GetTweetById(int id);
        public Task CreateTweet(Tweet newTweet);
        public Task UpdateTweet(int id, Tweet updatedTweet);
        public Task DeleteTweet(int id);

    }
}
