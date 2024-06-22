namespace ConsoleApp1
{
    internal class Program
    {
        private static void PrintThread(object x)
        {
            for (int i = 0; i < 10; i++)
            {
                //Console.WriteLine($"{Environment.CurrentManagedThreadId} + one");
                Console.WriteLine($"{x} + one");
                Console.WriteLine($"{x} + two");
                Console.WriteLine($"{x} + three");
            }
        }
        static void Main(string[] args)
        {
            // можно вот так
            //for (int x =0; x < 10;x++)
            //{
            //Thread t = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} + one");
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} + two");
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} + three");
            //    }
            //});
            //}
            for (int i = 0; i < 10; i++)
            {
                Thread t = new(PrintThread);
                t.Start(i);
            }
        }
    }
}