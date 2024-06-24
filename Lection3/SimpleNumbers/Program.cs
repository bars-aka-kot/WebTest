using System.Data;

namespace SimpleNumbers;

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
        for (int i  = 0; i < ints.Length; i++)
        {
            ints[i] = rnd.Next(100000000, 1000000000);
        }

        var res = Parallel.For(0, 1000000000, (i, state) =>
        {
            bool isPime = IsPrime(ints[i]);
            if (isPime)
            {
                if (Interlocked.Increment(ref total) < 10)
                {
                    Console.WriteLine(ints[i]);
                }
                else
                {
                    state.Break();
                }
            }
        });
        Console.WriteLine("done");
    }
}
