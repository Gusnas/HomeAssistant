using System;
using System.Threading;
using System.Text;
using RabbitMQ.Client;

namespace Sprinkler
{
    class SmokeSensor
    {
        public bool IsSmoke { get;private set; }

        public SmokeSensor(bool isSmoke)
        {
            IsSmoke = isSmoke;
        }

        public void SendState()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "data",
                                        type: "direct");
                var message = IsSmoke.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                while (true)
                {
                    channel.BasicPublish(exchange: "data",
                                         routingKey: "is_smoke",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent '{0}':'{1}'", "is_smoke", message);
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
