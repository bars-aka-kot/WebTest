using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    internal class Program
    {
        public static IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

        static void Recevier()
        {
            using (var client = new UdpClient(1234))
            {
                var lp = new IPEndPoint(IPAddress.Any, 1234);
                int count = 0;
                while (count < 9_000)
                {
                    var recv = client.Receive(ref lp);
                    foreach (var item in recv)
                    {
                        Console.Write(item + " ");
                    }
                    count += recv.Length;
                }
                Console.WriteLine("End");
            }
        }
        static void UdpSender(byte b)
        {
            using (var client = new UdpClient())
            {
                client.Connect(ep);
                for (int i = 0; i < 3_000; i++)
                {
                    client.Send(new byte[] { b });
                }
            }
        }
        static void Main(string[] args)
        {
            new Thread(Recevier).Start();

            for (int i = 0; i < 3; i++) { 
                byte t = (byte)i;
                new Thread(() => { UdpSender(t); }).Start();
            }

        }
    }
}
