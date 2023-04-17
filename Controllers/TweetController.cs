using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tweet_service.Exceptions;
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
        private readonly ILogger<TweetController> _logger;
        private readonly IConfiguration _config;

        public TweetController(ITweetService tweetService, IMapper mapper, ILogger<TweetController> logger, IConfiguration config)
        {
            _tweetService = tweetService;
            _mapper = mapper;
            _logger = logger;
            _config = config;
        }


        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetTweets()
        {
            return await _tweetService.GetAllTweets();
        }

        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet(TweetCreateDto tweetCreateDto)
        {
            try
            {
                return await _tweetService.CreateTweet(_mapper.Map<Tweet>(tweetCreateDto));
            }
            catch (NullTweetException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (TweetServiceException ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
