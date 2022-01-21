using System;
using RabbitMQ.Client;
using System.Threading;


namespace AirConditioner
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Set the initial temperature");
            double temp = double.Parse(Console.ReadLine());
            TempSensor sensor = new TempSensor(temp);
           
            // Instancia um objeto do tipo thread, e passando metodo desejado via delegate
            Thread SendTemp = new Thread(
                new ThreadStart(sensor.SendTemp));

            // Inicia a thread
            SendTemp.Start();

        }
    }
}
