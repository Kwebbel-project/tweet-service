using Confluent.Kafka;

namespace tweet_service.Common.Kafka
{
    public class KafkaProducerHandler
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
            _logger.LogInformation("kafkaconfig: " + configuration["Kafka:BootstrapServers"]);
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task<bool> sendMessage(Topics topic, string message)
        {
            try
            {
                switch (topic)
                {
                    //TODO: create string from enum
                    case Topics.TWEET_CREATED:
                        await _producer.ProduceAsync("TWEET_CREATED", new Message<Null, string> { Value = message });
                        break;
                    case Topics.TWEET_UPDATED:
                        await _producer.ProduceAsync("TWEET_UPDATED", new Message<Null, string> { Value = message });
                        break;
                    case Topics.TWEET_DELETED:
                        await _producer.ProduceAsync("TWEET_DELETED", new Message<Null, string> { Value = message });
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
