using System;
using System.Threading;

namespace SSLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tServer = new Thread(Server.StartServer);
            tServer.Start();

            Client.ConnectAndSend();


            Console.ReadLine();
        }
    }
}
