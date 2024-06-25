using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var t = Task.Run(() => ServerListener("Hello!"));
            Task.WaitAll(t);
        }
        public static void ServerListener(string name)
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

            Console.WriteLine("Server waits message from client");

            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);

                Task.Run(() =>
                {
                    Message? message = Message.DeserializeMessgeFromJSON(messageText);
                    message?.PrintGetMessageFrom();
                    byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");
                    udpClient.Send(reply, reply.Length, iPEndPoint);
                });
            }
        }

    }
}

