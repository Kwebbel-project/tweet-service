using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tweet_service.Models.Dto
{
    public class TweetCreateDto
    {
        [BsonElement("content")]
        [JsonPropertyName("content")]
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public long userId { get; set; }
    }
}
