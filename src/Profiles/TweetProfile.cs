using AutoMapper;
using tweet_service.Models;
using tweet_service.Models.Dto;

namespace tweet_service.Profiles
{
    public class TweetProfile : Profile
    {
        public TweetProfile()
        {
            CreateMap<Tweet, TweetReadDto>();
            CreateMap<TweetCreateDto, Tweet> ();
        }
    }
}
