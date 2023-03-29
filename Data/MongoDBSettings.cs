namespace tweet_service.Data
{
    public class MongoDBSettings
    {
        public string HOST { get; set; } = null!;
        public string USER { get; set; } = null!;
        public string PASSWORD { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
