using System.Xml;

namespace Increments
{
    class Program
    {
        static int x = 0;
        static void Increment()
        {
            for (int i = 0; i < 10000; i++)
            {
                //Interlocked.Increment(ref x);
                x++;
            }
            //Console.WriteLine($"{Thread.CurrentThread.Name} done");
        }

        static void Main(string[] args)
        {
            for (int i = 0; i<10; i++) 
            {
                new Thread(Increment).Start();
            }
            Thread.Sleep(100);
            Console.WriteLine(x);
        }
    }
}
