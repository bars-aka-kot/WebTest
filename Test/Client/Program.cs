﻿using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UDPClient.SendMessageAsync();
        }
    }
}
