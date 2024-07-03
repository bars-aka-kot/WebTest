using DBTest1.Abstracts;
using DBTest1.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DBTest1.Services
{
    internal class UdpMessageSource : IMessageSource
    {
        private readonly UdpClient _udpClient;
        public UdpMessageSource()
        {
            _udpClient = new UdpClient();
        }
        public NetMessage Receive(ref IPEndPoint ep)
        {
            
            byte[] data = _udpClient.Receive(ref ep);
            string stf = Encoding.UTF8.GetString(data);
            return NetMessage.DeserializeMessgeFromJSON(stf) ?? new NetMessage();
        }

        public async Task Send(NetMessage message, IPEndPoint ep)
        {
            byte[] buffer = Encoding.UTF8.GetBytes
                (message.SerialazeMessageToJSON());

            await _udpClient.SendAsync(buffer, buffer.Length, ep);
        
        }
    }
}
