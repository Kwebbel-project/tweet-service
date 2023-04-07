using Confluent.Kafka;
using tweet_service.Common.Kafka.Interfaces;

namespace tweet_service.Common.Kafka
{
    public class KafkaProducerHandler : IKafkaProducerHandler
    {
        private readonly ILogger<KafkaProducerHandler> _logger;
        private IProducer<Null, string> _producer;

        public KafkaProducerHandler(ILogger<KafkaProducerHandler> logger, IConfiguration configuration)
        {
            _logger = logger;
            var config = new ProducerConfig()
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task<bool> sendMessage(Topics topic, string message)
        {
            try
            {
                switch (topic)
                {
                    case Topics.TWEET_CREATED:
                        await _producer.ProduceAsync(Topics.TWEET_CREATED.ToString(), new Message<Null, string> { Value = message });
                        break;
                    case Topics.TWEET_UPDATED:
                        await _producer.ProduceAsync(Topics.TWEET_UPDATED.ToString(), new Message<Null, string> { Value = message });
                        break;
                    case Topics.TWEET_DELETED:
                        await _producer.ProduceAsync(Topics.TWEET_DELETED.ToString(), new Message<Null, string> { Value = message });
                        break;
                    default:
                        break;
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
            return await Task.FromResult(false);
        }
    }
}
