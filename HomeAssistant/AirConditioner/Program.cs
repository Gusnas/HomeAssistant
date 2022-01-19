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
            
            TempSensor sensor = new TempSensor(30);
           
            // Instancia um objeto do tipo thread, e passando metodo desejado via delegate
            Thread InstanceCaller = new Thread(
                new ThreadStart(sensor.SendTemp));

            // Inicia a thread
            InstanceCaller.Start();

        }
    }
}
