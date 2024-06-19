using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server("Hello!");
        }
        public static void Server(string name)
        {

            var listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                //Console.WriteLine("Connected");
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());
                var s = reader.ReadLine();
                Console.WriteLine(s);
                writer.Write(s);
                writer.Flush();

                UdpClient udpClient = new UdpClient(12345);
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Console.WriteLine("Server waiting message from client");

                while (true)
                {
                    byte[] buffer = udpClient.Receive(ref iPEndPoint);
                    if (buffer == null) break;
                    var messageText = Encoding.UTF8.GetString(buffer);
                    Message? message = Message.DeserializeFromJson(messageText);
                    message?.Print();
                }

            }


            
        }
    }
}