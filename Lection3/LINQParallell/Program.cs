namespace LINQParallell
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
                ints[i] = rnd.Next(10000000, 1000000000);
            }
            var res = ints.AsParallel().Where(IsPrime).AsSequential().Take(10);
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}
