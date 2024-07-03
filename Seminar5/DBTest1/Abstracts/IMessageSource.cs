using DBTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DBTest1.Abstracts
{
    internal interface IMessageSource
    {
        Task Send(NetMessage message, IPEndPoint ep);

        NetMessage Receive(ref IPEndPoint ep);
    }
}
