namespace FibonachiNumbers
{
    class Program
    {
        static async Task<int> Fibonachi(int x)
        {
            return await Task.Run(() =>
            {
                int a = 0, b = 1;
                for (int i = 0; i < x - 2; i++)
                {
                    int t = b + a;
                    a = b;
                    b = t;
                }
                return b;
            });
        }
        static async Task Main(string[] args)
        {
            var task1 = Fibonachi(10000);
            var task2 = Fibonachi(10000);
            int res = await task1 + await task2;
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
