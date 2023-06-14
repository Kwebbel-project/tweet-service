using tweet_service.Common.Kafka;
using tweet_service.Common.Kafka.Interfaces;

namespace tweet_service.Tests.Mock
{
    public class MockKafkaClient : IKafkaProducerHandler
    {
        public Task<bool> sendMessage(Topics topic, string message)
        {
            return Task.FromResult(true);
        }
    }
}
