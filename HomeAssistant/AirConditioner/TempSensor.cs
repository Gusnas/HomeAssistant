using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace AirConditioner
{
    class TempSensor
    {
        public double InitTemp { get; private set; }
        private Random rand = new Random();

        public TempSensor(double initial_temperature)
        {
            InitTemp = initial_temperature;
        }

        // Metodo pra variar temperatura usando variaveis double randomicas
        public void TempVar()
        {
            while (true)
            {
                InitTemp = InitTemp - rand.NextDouble();
                Thread.Sleep(3000);
            }

        }

        //Enviando temperatura fixa , editar posteriormente 
        public void SendTemp()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "data",
                                        type: "direct");
                var message = InitTemp.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                while (true)
                {
                    channel.BasicPublish(exchange: "data",
                                         routingKey: "ac_temp",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent '{0}':'{1}'", "ac_temp", message);
                    Thread.Sleep(1000);
                }
            }

        }

    }

}

