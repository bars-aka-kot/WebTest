using System.Net;
using System.Net.Sockets;

namespace ServerListenerEasy;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        var listener = new TcpListener(IPAddress.Any, 12345);
        listener.Start();

        using (TcpClient client = listener.AcceptTcpClient())
        {
            Console.WriteLine("Connected");

            var reader = new StreamReader(client.GetStream());
            var writer = new StreamWriter(client.GetStream());
            var s = reader.ReadLine();
            Console.WriteLine(s);
            var r = new String(s?.Reverse().ToArray());
            writer.Write(r);
            writer.Flush();
        }
    }
}