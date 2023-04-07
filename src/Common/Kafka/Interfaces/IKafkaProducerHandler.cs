namespace tweet_service.Common.Kafka.Interfaces
{
    public interface IKafkaProducerHandler
    {
        public Task<bool> sendMessage(Topics topic, string message);
    }
}
