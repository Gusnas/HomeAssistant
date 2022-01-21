using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace Lamp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Insert the initial brightness");
            int brightness = int.Parse(Console.ReadLine());
            AmbLightSensor lght_sensor = new AmbLightSensor(brightness);
            // Instancia um objeto do tipo thread, e passando metodo desejado via delegate
            Thread SendBrightness_t = new Thread(
                new ThreadStart(lght_sensor.SendBrightness));

            // Inicia a thread
            SendBrightness_t.Start();
        }
    }
}