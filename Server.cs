using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SSLTest
{
    class Server
    {
        public static void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            Console.WriteLine("Starting TCP listener...");

            var listener = new TcpListener(ipAddress, 500);
            listener.Start();

            var data = new byte[8000];
            while (true)
            {
                var client = listener.AcceptSocket();

                for (;;)
                {
                    var size = client.Receive(data);
                    if (size <= 0)
                    {
                        break;
                    }
                    var truncatedArray = new byte[size];
                    Array.Copy(data, truncatedArray, truncatedArray.Length);
                    var output = Encoding.UTF8.GetString(truncatedArray);
                    Console.Write(output);

                }
                client.Close();



            }
        }
    }
}
