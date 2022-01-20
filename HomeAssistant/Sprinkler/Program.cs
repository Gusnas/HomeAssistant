using System;
using System.Threading;

namespace Sprinkler
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Is There Smoke? (True/False)");
            bool IsSmoke = bool.Parse(Console.ReadLine());
            SmokeSensor smk_sensor = new SmokeSensor(IsSmoke);
            // Instancia um objeto do tipo thread, e passando metodo desejado via delegate
            Thread SendState_t = new Thread(
                new ThreadStart(smk_sensor.SendState));

            // Inicia a thread
            SendState_t.Start();
        }
    }
}
