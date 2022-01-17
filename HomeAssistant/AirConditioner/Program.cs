using System;
using RabbitMQ.Client;
using System.Threading;

namespace AirConditioner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira a temperatura inicial");
            float temp = float.Parse(Console.ReadLine());
            TempSensor sensor = new TempSensor(temp);
            sensor.TempVar();

        }
    }
}
