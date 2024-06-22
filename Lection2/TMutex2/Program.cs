namespace TMutex2
{
    class Program
    {
        static Mutex mtx = null;

        static void ThreadProc()
        {
            try
            {
                mtx.WaitOne();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {i}");
                }
            }
            finally
            {
                mtx.ReleaseMutex();
            }
        }
        static void Main(string[] args)
        {
            mtx = new Mutex(true);
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(ThreadProc);
                t.Name = "Thread " + i;
                t.Start();
            }
            Console.WriteLine("Освобождаем поток");

            mtx.ReleaseMutex();
        }
    }
}
