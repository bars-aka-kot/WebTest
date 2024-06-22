using System.Net;
using Server;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) 
            {
                SendMessage("Artem", i);
            }
            Console.ReadKey();
        }
        public static void SendMessage(string from, int i, string ip = "127.0.0.1")
        {
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);


                string? messageText = "Привет!" + i;
                //do
                //{
                //    Console.Clear();
                //    Console.WriteLine("Input your message");
                //    messageText = Console.ReadLine();
                //} while (string.IsNullOrEmpty(messageText));

                Message message = new Message { Text = messageText, NickNameFrom = from, NickNameTo = "Server", DateTime = DateTime.Now };
                string json = message.SerialazeMessageToJSON();
                byte[] data = Encoding.UTF8.GetBytes(json);
                udp.Send(data, data.Length, iPEndPoint);

                byte[] buffer = udp.Receive(ref iPEndPoint);
                messageText = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(messageText);

            
        }
    }
}
