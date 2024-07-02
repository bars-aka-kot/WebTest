using System.Net.Sockets;
using System.Net;
using System.Text;

namespace DBTest1
{
    public class Server
    {
        private readonly UdpClient _udpClient;
        private IPEndPoint _iPEndPoint;
        private Manager? _manager;
        public Server()
        {
            _udpClient = new UdpClient(12345);
            _iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _manager = new Manager(this);
        }

        public NetMessages Listener()
        {
            byte[] buffer = _udpClient.Receive(ref _iPEndPoint);
            var messageText = Encoding.UTF8.GetString(buffer);
            NetMessages? message = NetMessages.DeserializeMessgeFromJSON(messageText);
            return message;
        }
        public void Send(TypeSend type, NetMessages msg)
        {
            byte[] reply = Encoding.UTF8.GetBytes(msg.SerialazeMessageToJSON());
            switch (type)
            {
                case TypeSend.MassSend:
                    foreach (var ip in Clients.Values)
                        _udpClient.Send(reply, reply.Length, _iPEndPoint);
                    break;
                case TypeSend.OneSend:
                    if (Clients.TryGetValue(msg.NickNameTo, out IPEndPoint iep))
                        _udpClient.Send(reply, reply.Length, _iPEndPoint);
                    break;
                default: break;

            }
        }
        public Dictionary<string, IPEndPoint>? Clients { get; set; }
        public static string Name = "Server";
        public void StartServer()
        {
            Console.WriteLine("Server waits message from client");
            while (true)
            {
                var newMessage = Listener();
                var typesend = _manager.Execute(newMessage, _iPEndPoint);

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Send(typesend, newMessage);
                });
            }
        }
    }
}
