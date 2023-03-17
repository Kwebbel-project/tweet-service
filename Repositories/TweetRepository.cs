using Microsoft.Extensions.Options;
using MongoDB.Driver;
using tweet_service.Data;
using tweet_service.Models;

namespace tweet_service.Repositories
{
    public class TweetRepository
    {
        private readonly IMongoCollection<Tweet> _tweetsCollection;

        public TweetRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _tweetsCollection = mongoDatabase.GetCollection<Tweet>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Tweet>> GetAsync() =>
        await _tweetsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Tweet newTweet) =>
        await _tweetsCollection.InsertOneAsync(newTweet);
    }
}
