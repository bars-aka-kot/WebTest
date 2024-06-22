namespace Priority
{
    class Program
    {
        private static void Counter(int time)
        {
            for (int i = time; i>=1; i--) 
            { 
                Console.WriteLine(i); 
                Thread.Sleep(1000);
            } 
        }
        static bool isActive = true;
        static void ThreadProc()
        {
            long c = 0;
            while (isActive)
            {
                c++;
            }
            var t = Thread.CurrentThread;
            Console.WriteLine($"Thread {t.Name} with priority {t.Priority} made {c} iterations");
        }
        static void Main(string[] args)
        {
            //var t = new Thread(
            //() =>
            //{
            //    for (int i = 0; i <=10; i++) {
            //        Console.WriteLine(".");
            //        Thread.Sleep(100);
            //    }
            //});
            var t1 = new Thread(ThreadProc);
            t1.Priority = ThreadPriority.Lowest;
            t1.Name = "t1"; 
            var t2 = new Thread(ThreadProc);
            t2.Priority = ThreadPriority.Normal;
            t2.Name = "t2"; 
            var t3 = new Thread(ThreadProc);
            t3.Priority = ThreadPriority.Highest;
            t3.Name = "t3";

            Console.WriteLine(t1.ThreadState);
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine(t1.ThreadState);
            int time = 10;
            Counter(time);
           // Thread.Sleep(10000);

            isActive = false;
            Console.WriteLine(t1.ThreadState);
            Thread.Sleep(500);
            Console.WriteLine(t1.ThreadState);
            //t.IsBackground = true;
            //t.Start();
            //Thread.Sleep(500);
        }
    }
}
