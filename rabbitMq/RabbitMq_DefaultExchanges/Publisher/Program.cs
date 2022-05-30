using RabbitMQ.Client;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://user:user1234@192.168.1.203:5672")
};

using (var connection = connectionFactory.CreateConnection())
using(var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "dev-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    while (true)
    {
        string message = $"{DateTime.Now:HH:mm:ss.fff} Message form publicher.";
        byte[] body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "", routingKey: "dev-queue", basicProperties: null, body: body);
        
        Console.Title = "Publisher";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} Message was sent to Default Exchange");
        
        Thread.Sleep(1000);
    }
}