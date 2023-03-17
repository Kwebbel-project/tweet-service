using System.ComponentModel.DataAnnotations;

namespace tweet_service.Models.Dto
{
    public class TweetCreateDto
    {

        [Required]
        public string Content { get; set; }
        [Required]
        public long userId { get; set; }
    }
}
