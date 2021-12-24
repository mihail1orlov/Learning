using Common.Model;
using ProtoBuf;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory connectionFactory = new()
{
    HostName = "192.168.5.5",
    Port = 5009,
    Password = "12344321",
    UserName = "guest"
};

string[] arg = Environment.GetCommandLineArgs();

Console.WriteLine($"routingKey: {string.Join(", ", arg)}");
Console.ForegroundColor = ConsoleColor.Green;

Func<string, Action> task = (routingKey) =>
{
    return () =>
    {
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        const string exchange = "moon_logs";
        channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);

        var queue = channel.QueueDeclare().QueueName;
        channel.QueueBind(queue, exchange, routingKey);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (sender, e) =>
        {
            var user = Serializer.Deserialize<User>(e.Body);

            Console.WriteLine($"RoutingKey: {routingKey}, Received message: {user}");
        };

        channel.BasicConsume(queue, autoAck: true, consumer);

        Console.ReadLine();
    };
};

for (var i = 1; i < arg.Length; i++)
{
    Task.Run(task(arg[i]));
    Console.WriteLine($"Subscribed the the queue: '{arg[i]}'");
}

Console.Title = "Consumer";
Console.ReadLine();