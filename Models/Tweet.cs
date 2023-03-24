using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tweet_service.Models
{
    public class Tweet
    {
        [BsonId]
        [JsonPropertyName("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("content")]
        [JsonPropertyName("content")]
        [Required]
        public string Content { get; set; }
        [BsonElement("author")]
        [JsonPropertyName("author")]
        [Required]
        public string Author { get; set; }      
        [Required]
        [BsonElement("likes")]
        [JsonPropertyName("likes")]
        public int Likes { get; set; }
        [Required]
        [BsonElement("created_at")]
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [BsonElement("user_id")]
        [JsonPropertyName("userId")]
        public long userId { get; set; }
    }
}
