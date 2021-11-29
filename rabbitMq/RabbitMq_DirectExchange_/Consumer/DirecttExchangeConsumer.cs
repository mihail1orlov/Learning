using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class DirecttExchangeConsumer
{
    internal static void Consume(IModel channel)
    {
        string exchange = "demo-direct-exchange";
        channel.ExchangeDeclare(exchange, ExchangeType.Direct);
        
        string queue = "demo-direct-queue";
        channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

        channel.QueueBind(queue, exchange, routingKey: "account.init");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
        };

        channel.BasicConsume(queue, autoAck: true, consumer);

        Console.WriteLine("Consumer started");
        Console.ReadLine();
    }
}