using Patterns;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    internal class Program
    {
        public static UdpClient udp = new UdpClient();
        public static IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        static void Main(string[] args)
        {
            static async Task Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Run(() => SendMessage("Artem", i));
                }
                Console.ReadKey();
            }
            static void SendMessage(string from, int i, string ip = "127.0.0.1")
            {
                byte[] buffer = udp.Receive(ref iPEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(messageText);
            }
        }
        public static void Operation1()
        {
            Message message = new Message { Text = "Привет", NickNameFrom = "Artem", NickNameTo = "Server", DateTime = DateTime.Now, command = Commands.Register };
            string json = message.SerialazeMessageToJSON();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udp.Send(data, data.Length, iPEndPoint);
        }
        public static void Operation4()
        {
            Message message = new Message { Text = "Привет", NickNameFrom = "Sergey", NickNameTo = "Server", DateTime = DateTime.Now, command = Commands.Register };
            string json = message.SerialazeMessageToJSON();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udp.Send(data, data.Length, iPEndPoint);
        }
        public static void Operation3()
        {
            Message message = new Message { Text = "Привет", NickNameFrom = "Artem", NickNameTo = "Sergey", DateTime = DateTime.Now, command = Commands.Delete };
            string json = message.SerialazeMessageToJSON();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udp.Send(data, data.Length, iPEndPoint);
        }
        public static void Operation2()
        {
            Message message = new Message { Text = "Привет", NickNameFrom = "Artem", NickNameTo = "Server", DateTime = DateTime.Now};
            string json = message.SerialazeMessageToJSON();
            byte[] data = Encoding.UTF8.GetBytes(json);
            udp.Send(data, data.Length, iPEndPoint);
        }
    }
}
