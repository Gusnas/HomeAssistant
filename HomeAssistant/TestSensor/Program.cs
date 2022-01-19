using System;
using RabbitMQ.Client;
using System.Text;

class TestSensor
{
    public static void Main(string[] args)
    {
        int test = 25;
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())

        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "data", type: ExchangeType.Direct);

            var message = test.ToString();
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "data",
                                 routingKey: "rt_test",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
