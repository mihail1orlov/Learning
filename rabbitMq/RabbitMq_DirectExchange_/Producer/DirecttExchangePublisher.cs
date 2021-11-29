using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

internal static class DirecttExchangePublisher
{
    public static void Publish(IModel channel)
    {
        string exchange = "demo-direct-exchange";
        channel.ExchangeDeclare(exchange, ExchangeType.Direct);
        for (int i = 0; true; i++)
        {
            var message = new { Name = "Producer", Message = $"Hello! Count: {i}" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            string routingKey = "account.init";
            channel.BasicPublish(exchange, routingKey, null, body);

            Console.WriteLine(message);
            Thread.Sleep(500);
        }
    }
}