namespace tweet_service.Exceptions
{
    public class NullTweetException : ArgumentNullException
    {
        public NullTweetException() : base("Tweet was null.") { }

    }
}
