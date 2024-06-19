using Server;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение");

            using (TcpClient client = new TcpClient())
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 12345);
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());
                
                writer.WriteLine();
                writer.Flush();

                Console.WriteLine(reader.ReadLine());
            }

           
        }
        public static void SendMessage(string from, string to, string ip)
        {
            

            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            
            while(true) 
                {
                string? message;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите сообщение");
                    message = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(message));
                Message msg = new Message()
                {
                    Text = "<" + message + ">",
                    DateTime = DateTime.Now,
                    NickNameFrom = from,
                    NickNameTo = to
                };
                string json = msg.SerializeMessageToJson();

                byte[] bufferData = Encoding.UTF8.GetBytes(json);
                udpClient.Send(bufferData, bufferData.Length, ipEndPoint);
            }
        }
    }
}