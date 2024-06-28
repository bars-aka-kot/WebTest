using System.Net;

namespace Patterns
{

    public class Manager
    {
        public Server _server;
        public Manager(Server server) => _server = server;

        public void Delete(string clientName)
        {
            _server.Clients.Remove(clientName);
            Console.WriteLine($"{clientName} удален с сервера");
        }

        public void Register(string clientName, IPEndPoint iPEndPoint)
        {
            if (_server.Clients == null)
                _server.Clients = new Dictionary<string, IPEndPoint>();
            _server.Clients.Add(clientName, iPEndPoint);
            Console.WriteLine($"{clientName} зарегистрирован на сервере");
        }
        public TypeSend Execute(Message msg, IPEndPoint iPEndPoint)
        {
            switch (msg.command)
            {
                case Commands.Delete:
                    Delete(msg.NickNameFrom);
                    break;
                case Commands.Register:
                    Register(msg.NickNameFrom, iPEndPoint);
                    break;
                default: return Send(msg);
            }
            return TypeSend.DefaultSend;
        }

        public TypeSend Send(Message msg)
        {
            if (string.IsNullOrEmpty(msg.NickNameFrom))
                return TypeSend.MassSend;
            else return TypeSend.OneSend;
        }

        public void View()
        {
            foreach (var item in _server.Clients)
            {
                Console.WriteLine($"Client - {item.Key} with ip {item.Value}");
            }
        }
    }
}
