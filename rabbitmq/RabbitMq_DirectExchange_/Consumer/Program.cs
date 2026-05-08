using RabbitMQ.Client;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://guest:guest@192.168.1.203:5672")
};

Console.ForegroundColor = ConsoleColor.Green;

using (var connection = connectionFactory.CreateConnection())
using (var channel = connection.CreateModel())
    DirecttExchangeConsumer.Consume(channel);

Console.ReadKey();