using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tweet_service.Models;
using tweet_service.Services;

namespace tweet_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly TweetService _tweetService;

        public TweetController(TweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetTweets(Tweet tweet)
        {
            return await _tweetService.GetAllTweets();
        }

        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
        {
            return await _tweetService.CreateTweets(tweet);
        }
    }
}
