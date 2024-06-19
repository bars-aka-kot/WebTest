namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new UDPServer();
            server?.ServerListenerAsync();
        }
    }
}
