namespace tweet_service.Exceptions
{
    public class TweetServiceException : Exception
    {
        public TweetServiceException(string message) : base(message) { }
    }
}
