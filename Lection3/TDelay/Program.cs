namespace TDelay
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("First");
            Task.Delay(2000); // определяет время работы Task
            Console.WriteLine("Second");
        }
    }
}
