using System.Net.Http.Headers;

namespace Semaphores
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(3, 3);
        static void ThreadProc(int x)
        {
            try
            {
                semaphore.WaitOne();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(x + " ");
                    Thread.Sleep(1000);
                }
                Console.WriteLine();
            }
            finally
            {
                semaphore.Release();
            }
        }
        
        static void Main(string[] args)
        {
            for (int i = 0; i<10 ; i++) 
            {
                int x = i;
                new Thread(() => { ThreadProc(x); }).Start();
            }
        }
    }
}
