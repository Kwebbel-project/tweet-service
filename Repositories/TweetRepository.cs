using tweet_service.Data;
using tweet_service.Models;
using tweet_service.Repositories.Interfaces;

namespace tweet_service.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly ApiDbContext _context;

        public TweetRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void CreateTweet(Tweet tweet)
        {
            if (tweet == null)
            {
                throw new ArgumentNullException(nameof(tweet));
            }
            _context.Tweets.Add(tweet);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
