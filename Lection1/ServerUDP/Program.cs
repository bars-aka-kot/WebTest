using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerUDP;

internal class Program
{
    static void Main(string[] args)
    {
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            var localEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 1234);
            socket.Bind(localEndPoint);

            byte[] buffer = new byte[1];
            int count = 0;
            while (count < 200)
            {
                EndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                var sf = new SocketFlags();
                //int c = socket.ReceiveFrom(buffer, ref endpoint);
                int c = socket.ReceiveMessageFrom(buffer, 0, 1, ref sf, ref endpoint, out IPPacketInformation info);
                Console.WriteLine(buffer[0]);
                if (c == 1) 
                {
                    //if((endpoint as IPEndPoint)?.Port == 2234)
                    //    Console.Write(buffer[0]); 
                    var buffOut = new byte[1]{(byte)(buffer[0] * 2)};
                    socket.SendTo(buffOut,endpoint);
                }
                count += c;
            }
            Console.WriteLine("\nПрочитали 200 байт");
        }
    }
}