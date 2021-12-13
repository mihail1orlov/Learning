using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://moon:12344321@192.168.1.202:5672")
};

string[] arg = Environment.GetCommandLineArgs();

Console.WriteLine($"routingKey: {string.Join(", ", arg)}");
Console.ForegroundColor = ConsoleColor.Green;

Func<string, Action> task = (routingKey) =>
{
    return () =>
    {
        using (var connection = connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            string exchange = "moon_logs";
            channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);

            var queue = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue, exchange, routingKey);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine($"Received message: {message}");
            };

            channel.BasicConsume(queue, autoAck: true, consumer);

            Console.ReadLine();
        }
    };
};

for (int i = 1; i < arg.Length; i++)
{
    Task.Run(task(arg[i]));
    Console.WriteLine($"Subscribed the the queue: '{arg[i]}'");
}

Console.Title = "Consumer";
Console.ReadLine();