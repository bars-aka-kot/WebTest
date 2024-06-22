using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace PingToServer
{
    internal class Program
    {
        const string site = "www.yandex.ru";
        static void Main(string[] args)
        {
            IPAddress[] ipAdress = Dns.GetHostAddresses(site, AddressFamily.InterNetwork);
            foreach (IPAddress ip in ipAdress)
            {
                Console.WriteLine(ip.ToString());
            }
            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();

            List<Thread> threads = new List<Thread>();

            foreach (IPAddress item in ipAdress)
            {
                var thread = new Thread(() => {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(item);
                    pings.Add(item, pingReply.RoundtripTime);
                    Console.WriteLine(item + " - " + pingReply.RoundtripTime);

                });
                threads.Add(thread);
                thread.Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }
            long minPing = pings.Min(x => x.Value);
            Console.WriteLine(minPing);
        }

    }
}

/*
 * foreach (var item in iPAddress)
{
Thread tr = new Thread(() =>
{
Ping ping = new Ping();
PingReply pr = ping.Send(item);
pings.Add(item, pr.RoundtripTime);
Console.WriteLine($"{item} {pr.RoundtripTime}");

});
tr.Start();
tr.Join();
}
 */