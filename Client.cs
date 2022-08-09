using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;

namespace SSLTest
{
    class Client
    {
        public static void ConnectAndSend()
        {
            
            var client = new TcpClient();
            client.Connect("127.0.0.1", 500);
            var s = client.GetStream();
            var bMessage = Encoding.UTF8.GetBytes("HELLO WORLD");

       
            // ssl
            var ssl = new SslStream(s);
            ssl.AuthenticateAsClient("SOME SECRET INFORMATION", null, SslProtocols.Tls12, false);
            ssl.Write(bMessage, 0, bMessage.Length);
            ssl.Close();

            s.Close();
             
        }
    }
}
