using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Pings
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string site = "www.yandex.ru";
            IPAddress[] ipAdress = Dns.GetHostAddresses(site, AddressFamily.InterNetwork);
            foreach (IPAddress ip in ipAdress)
            {
                Console.WriteLine(ip.ToString());
            }
            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();

            List<Task> tasks = new List<Task>();

            foreach (IPAddress item in ipAdress)
            {
                var task =  Task.Run(async () =>
                {
                    Ping ping = new Ping();
                    PingReply pingReply = await ping.SendPingAsync(item);
                    pings.Add(item, pingReply.RoundtripTime);
                    Console.WriteLine(item + " - " + pingReply.RoundtripTime);
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            long minPing = pings.Min(x => x.Value);
            Console.WriteLine(minPing);
        }

    }
}

