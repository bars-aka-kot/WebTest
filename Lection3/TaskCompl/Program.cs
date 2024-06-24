namespace TaskCompl
{
    class Program
    {
        static byte[] GenerateNumbers()
        {
            var rand = new Random();
            byte[] b = new byte[100];
            rand.NextBytes(b);

            foreach (var x in b)
                Console.WriteLine(x + " ");
            Console.WriteLine();

            return b;
        }
        static int FindMinimum(Task<byte[]> task)
        {
            var b = task.Result;
            var min = b[0];
            foreach (var n in b)
                if (min > n)
                    min = n;
            return min;
        }
        static async Task Main(string[] args)
        {
            var t1 = new Task<byte[]>(GenerateNumbers);
            var t2 = t1.ContinueWith((x) => { return FindMinimum(x); });
        
            t1.Start();
            t2.Wait();
            Console.WriteLine(t2.Result);
        }
    }
}
