namespace TMutex4
{
    class Program
    {
        static Mutex mtx = new Mutex();
        static void ThreadProc()
        {
            
        }
        static void Main(string[] args)
        {
            mtx.WaitOne();
            new Thread(() =>
            {
                if (mtx.WaitOne(200))
                {
                    Console.WriteLine("Mutex acquired");
                    mtx.ReleaseMutex();
                }
                else { Console.WriteLine("Mutex not acquired"); }
            }).Start();
            Thread.Sleep(1000);
            mtx.ReleaseMutex();
        }
    }
}
