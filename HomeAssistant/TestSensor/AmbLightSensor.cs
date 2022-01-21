using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using System.Threading;

namespace Lamp
{
    class AmbLightSensor
    {
        public int Brightness { get;private set; }

        public AmbLightSensor(int brightness)
        {
            Brightness = brightness;
        }

        public void SendBrightness()
        {
            int test = 25;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())


            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "data", type: ExchangeType.Direct);

                var message = test.ToString();
                var body = Encoding.UTF8.GetBytes(message);
                while (true)
                {
                    channel.BasicPublish(exchange: "data",
                                         routingKey: "brightness",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                    Thread.Sleep(1000);
                }

            }
        }
        
    }
}
