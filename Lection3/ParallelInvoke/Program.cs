namespace ParallelInvoke
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parallel.Invoke(
                new Action[]
                {
                    () => { Thread.Sleep(1000); Console.WriteLine(1); },
                    () => { Thread.Sleep(1000); Console.WriteLine(2); },
                    () => { Thread.Sleep(1000); Console.WriteLine(3); },
                    () => { Thread.Sleep(1000); Console.WriteLine(4); },
                    () => { Thread.Sleep(1000); Console.WriteLine(5); },
                    () => { Thread.Sleep(1000); Console.WriteLine(6); }
                });
        }
    }
}

