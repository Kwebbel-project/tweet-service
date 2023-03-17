using tweet_service.Models;

namespace tweet_service.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        bool SaveChanges();
        void CreateTweet(Tweet tweet);
    }
}
