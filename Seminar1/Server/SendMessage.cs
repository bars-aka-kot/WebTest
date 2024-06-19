using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class SendMessages
    {
        static void SendMessage()
        {
            using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
                listener.Blocking = true;
                listener.Bind(remoteEndPoint);
                listener.Listen(100);
                Console.WriteLine("Wait");
                var socket = listener.Accept();
                Console.WriteLine("Connected");
                listener.Close();
            }
        }
    }
}
