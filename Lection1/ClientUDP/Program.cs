using System.Net;
using System.Net.Sockets;

namespace ClientUDP
{
    class Program
    {
        static void Send(byte[] buffer, Socket socket)
        {
            for (int i = 0; i < 100; i++)
            {
                socket.Send(buffer);
                var buffIn = new byte[1];

                 //socket.Shutdown(SocketShutdown.Receive);     // запрет получения данных
                // socket.Shutdown(SocketShutdown.Send);        // запрет отправки данных
                // socket.Shutdown(SocketShutdown.Both);        // запрет отправки и получения данных


                int count = socket.Receive(buffIn);
                if (count == 1)
                {
                    Console.Write($"{buffer[0]} x 2 = " + buffIn[0] + " ");
                }
            }
            socket.Close();
        }
        static void Main(string[] args)
        {
            Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            var localEP1 = new IPEndPoint(IPAddress.Any, 2234);
            var localEP2 = new IPEndPoint(IPAddress.Any, 2235);

            socket1.Bind(localEP1);
            socket2.Bind(localEP2);

            socket1.Connect("127.0.0.1", 1234);
            socket2.Connect("127.0.0.1", 1234);

            (new Thread(() => Send(new byte[] { 3 }, socket1))).Start();
            (new Thread(() => Send(new byte[] { 4 }, socket2))).Start();

        }
    }
}
