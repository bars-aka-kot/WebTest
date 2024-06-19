using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace Client;

internal class Program
{
    static void Main(string[] args)
    {
        using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12346);
            client.Bind(localEndPoint);
            Console.WriteLine("Connecting...");
            try
            {
                client.Connect(remoteEndPoint);
            }
            catch(SocketException e)
            { Console.WriteLine(e.ErrorCode + " " + e.Message); }
            if (client.Connected)
            {
                Console.WriteLine("Connected!");
                Console.WriteLine($"localEndPoint = {client.LocalEndPoint}");
                Console.WriteLine($"remoteEndPoint = {client.RemoteEndPoint}");
            }
            else
            {
                Console.WriteLine("Connection problem");
                return;
            }



            byte[] bytes = Encoding.UTF8.GetBytes("Привет!");

            if (client.Poll(100, SelectMode.SelectWrite) && !client.Poll(100,SelectMode.SelectError))
            {
                int count = client.Send(bytes);
                if (count == bytes.Length)
                {
                    Console.WriteLine("Отправлено");
                }
                else
                {
                    Console.WriteLine("Что-то пошло не так");
                }
            }
        }
    }
}
