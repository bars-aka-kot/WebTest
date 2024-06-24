namespace PIAsyncEnumerable
{
    class Program
    {
        static async IAsyncEnumerable<int> AsyncNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                await Task.Delay(100);
                yield return number;
            }
        }
        static async Task GetNumbers()
        {
            List<int> ints = new List<int> { 1,2,3,4,5};
            await foreach(int n in AsyncNumbers(ints))
            {
                Console.WriteLine(n);
            }
        }
        static async Task Main(string[] args)
        {
            var t = GetNumbers();
            Console.WriteLine("Working");
            await t;
        }
    }
}
