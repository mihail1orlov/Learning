using RabbitMQ.Client;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://moon:12344321@192.168.1.202:5672")
};

string[] arg = Environment.GetCommandLineArgs();

Console.WriteLine($"routingKey: {string.Join(", ", arg)}");

Func<string, ConsoleColor, Action> task = (routingKey, color) =>
{
    return () =>
    {
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        string exchange = "moon_logs";
        channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);
        while (true)
        {
            string message = $"{DateTime.Now:HH:mm:ss.fff} Message type [{routingKey}] from publisher";
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange, routingKey, basicProperties: null, body);

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Thread.Sleep(new Random().Next(300, 3000));
        }
    };
};

for (int i = 1; i < arg.Length; i++)
{
    var name = $"Producer-{arg[i]}";
    Console.Title = name;
    Console.WriteLine(name);
    var colors = new[] { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Blue };
    Task.Run(task(arg[i], colors[i - 1]));
}

Console.ReadKey();