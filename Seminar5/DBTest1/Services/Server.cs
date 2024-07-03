using DBTest1.Abstracts;
using DBTest1.Models;
using System.Net;
using System.Net.Sockets;

namespace DBTest1.Services
{
    public class Server
    {
        Dictionary<string, IPEndPoint> _clients = new Dictionary<string, IPEndPoint>();
        private readonly IMessageSource _messageSource;
        private IPEndPoint ep;
        public Server()
        {
            _messageSource = new UdpMessageSource();
            ep = new IPEndPoint(IPAddress.Any, 0);
        }

        void Register(NetMessage message)
        {
            Console.WriteLine($"Registration " +
                $"{message.NickNameFrom}");
             
        }

        void ProcessMessage(NetMessage message)
        {
            switch (message.Command)
            {
                case Commands.Register:
                    break;
                case Commands.Message:
                    break;
                case Commands.Confirmation:
                    break;
                default: break;
            }
        }
        public void Start()
        {
            //UdpClient udpClient = new UdpClient(12345);

            Console.WriteLine("Server waits message from client");

            while (true)
            {
                try
                {
                    var message = _messageSource.Receive(ref ep);
                    Console.WriteLine(message.ToString());
                    ProcessMessage(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
