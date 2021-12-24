using Common.Model;
using RabbitMQ.Client;
using Common.Helper;

ConnectionFactory connectionFactory = new()
{
    HostName = "192.168.5.5",
    Port = 5009,
    Password = "12344321",
    UserName = "guest"
};

string[] arg = Environment.GetCommandLineArgs();

Console.WriteLine($"routingKey: {string.Join(", ", arg)}");

Func<string, ConsoleColor, Action> task = (routingKey, color) =>
{
    return () =>
    {
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        var exchange = "moon_logs";
        channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);
        while (true)
        {
            var user = new User
            {
                Name = "Bob",
                Age = 33,
                UpdateDate = DateTime.Now
            };

            var body = ProtoSerializer.Serialize(user);
            channel.BasicPublish(exchange, routingKey, basicProperties: null, body);

            Console.ForegroundColor = color;
            Console.WriteLine($"RoutingKey: {routingKey}, Sent message: {user}");
            Thread.Sleep(new Random().Next(300, 3000));
        }
    };
};

for (var i = 1; i < arg.Length; i++)
{
    var name = $"Producer-{arg[i]}";
    Console.Title = name;
    Console.WriteLine(name);
    var colors = new[] { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Blue };
    Task.Run(task(arg[i], colors[i - 1]));
}

Console.ReadKey();