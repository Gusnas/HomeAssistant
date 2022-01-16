using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            server.ReceiveMQ();
            Console.ReadKey();






        }
    }
}
