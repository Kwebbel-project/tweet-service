using Microsoft.Extensions.Options;
using MongoDB.Driver;
using tweet_service.Data;
using tweet_service.Models;
using tweet_service.Repositories.Interfaces;

namespace tweet_service.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly IMongoCollection<Tweet> _tweetsCollection;

        public TweetRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _tweetsCollection = mongoDatabase.GetCollection<Tweet>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Tweet>> GetAllTweets() =>
        await _tweetsCollection.Find(_ => true).ToListAsync();

        public async Task CreateTweet(Tweet newTweet) =>
        await _tweetsCollection.InsertOneAsync(newTweet);

        public async Task<Tweet> GetTweetById(string id) =>
        await _tweetsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateTweet(string id, Tweet updatedTweet) =>
        await _tweetsCollection.ReplaceOneAsync(x => x.Id == id, updatedTweet);

        public async Task DeleteTweet(string id) =>
        await _tweetsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
