using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KafkaApp
{
    class Program
    {
        internal class User
        {
            public User(double[,] o)
            {
                throw new NotImplementedException();
            }
        }


        static void Main(string[] args)
        {
            new User(null);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, collection) =>
            {
                collection.AddHostedService<KafkaProducerHostedService>();
            });
    }

    public class KafkaProducerHostedService : IHostedService
    {
        private readonly ILogger<KafkaProducerHostedService> _logger;
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
        {
            _logger = logger;

            _producer = new ProducerBuilder<Null, string>(
                new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                }).Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            for (var i = 0; i < 100; i++)
            {
                var message = $"Hello World {i}";
                _logger.LogInformation(message);
                await _producer.ProduceAsync("demo", new Message<Null, string>
                {
                    Value = message
                }, cancellationToken);

                _producer.Flush(TimeSpan.FromSeconds(10));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
