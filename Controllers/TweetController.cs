using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tweet_service.Models;

namespace tweet_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Tweet> PostTweet(Tweet tweet)
        {
            return null;
        }
    }
}
