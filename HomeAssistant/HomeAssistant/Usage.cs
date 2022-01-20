using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace HomeAssistant
{   
    class Usage
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Initialize("127.0.0.1", 27000);

            Client client = new Client();
            client.Initialize("127.0.0.1", 27000);
            client.Send("Testing!");




            // Instancia um objeto do tipo thread, e passando metodo desejado via delegate
            Thread ReceiveAC_t = new Thread(
                new ThreadStart(server.ReceiveAC));
            Thread ReceiveBr_t = new Thread(
                new ThreadStart(server.ReceiveLamp));
            Thread ReceiveSs_t = new Thread(
                new ThreadStart(server.ReceiveSmokeSensor));

            // Inicia a thread
            //server.ReceiveAC();
            ReceiveAC_t.Start();
            // Inicia a thread
            ReceiveBr_t.Start();
            // Inicia a thread
            ReceiveSs_t.Start();

            while (true)
            {
                
            
            }

        }
    }
}
