namespace SimpleNumbersForEach
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));
            for (var i = 2; i <= limit; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static async Task Main(string[] args)
        {
            int[] ints = new int[1000000000];
            int total = 0;
            var rnd = new Random();
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rnd.Next(100000000, 1000000000);
            }
            CancellationTokenSource cts = new CancellationTokenSource();
            var task = Parallel.ForEachAsync(ints, cts.Token, (i, ct) =>
            {
                bool isPime = IsPrime(ints[i]);
                if (isPime)
                {
                    Interlocked.Increment(ref total);
                    Console.WriteLine(i);
                }
                return ValueTask.CompletedTask;
            });
            Console.WriteLine("Started");
            await Task.Delay(1000);
            Console.WriteLine("Cancelling");
            cts.Cancel();
            try
            {
                await task;
            }
            catch { }
            Console.WriteLine("done, total = " + total);
        }
    }
}