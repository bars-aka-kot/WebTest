namespace SumTwoArr
{
    internal class Program
    {
        public static int _sum1 = 0;
        public static int _sum2 = 0;
        public static int[] _arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static int[] _arr2 = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

        public static async Task<int> Task1()
        {
            return await Task.Run(() => _arr1.Sum());
        }
        public static async Task<int> Task2()
        {
            return await Task.Run(() => _arr2.Sum());
        }

        public static async Task Main()
        {
            var t1 = Task1();
            var t2 = Task2();
            _sum1 = await t1;
            _sum2 = await t2;
            Console.WriteLine($"sum1 = {_sum1}, sum2 = {_sum2}, Общая сумма = {_sum1 + _sum2}");
        }
    }
}
