namespace all
{
    internal class Program
    {
        /*
        static void WriteParallel()
        {
            Console.WriteLine("Hello!");
        }
        static void Main(string[] args)
        {
            Action action = WriteParallel;
            Task t = new Task(action);
            t.Start();
            t.Wait();
        }
        */
        static private CancellationTokenSource cts = new CancellationTokenSource();
        static private CancellationToken ct = cts.Token;

        static void WriteParallel()
        {
            int c = 1;
            //При таком коде программа будет выполняться бесконечно
            //while (true)
            while(!cts.IsCancellationRequested)
            {
                Console.WriteLine("Привет! " + c++);
                Thread.Sleep(200);
            }
        }
        static void Main(string[] args)
        {
            Task t = new Task(WriteParallel, ct);
            t.Start();
            Thread.Sleep(10000);
            cts.Cancel();
            Console.WriteLine("Waiting for press key");
            Console.ReadKey();
        }
    }
}


