using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tweet_service.Models;
using tweet_service.Models.Dto;
using tweet_service.Services.interfaces;

namespace tweet_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;
        private readonly IMapper _mapper;

        public TweetController(ITweetService tweetService, IMapper mapper)
        {
            _tweetService = tweetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetTweets()
        {
            return await _tweetService.GetAllTweets();
        }

        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet(TweetCreateDto tweetCreateDto)
        {
            return await _tweetService.CreateTweet(_mapper.Map<Tweet>(tweetCreateDto));
        }
    }
}
