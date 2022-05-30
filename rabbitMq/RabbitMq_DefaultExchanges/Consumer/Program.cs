using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://user:user1234@192.168.1.203:5672")
};

using (var connection = connectionFactory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "dev-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

    EventingBasicConsumer consumer = new(channel);

    consumer.Received += (sender, args) =>
    {
        var body = args.Body;

        Console.Title = "Consumer";
        Console.ForegroundColor = ConsoleColor.Red;

        var message = Encoding.UTF8.GetString(body.ToArray());
        Console.WriteLine($"Received message: {message}");
    };

    channel.BasicConsume(
        queue: "dev-queue",
        autoAck: true,
        consumer: consumer
    );

    Console.WriteLine("Subscribed to the queue 'dev-queue'");
    Console.ReadKey();
}