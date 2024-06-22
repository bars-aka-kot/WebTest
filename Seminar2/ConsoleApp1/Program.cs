namespace ConsoleApp1
{
    internal class Program
    {
        private static int _sum1 = 0;
        private static int _sum2 = 0;
        private static int[] _arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static int[] _arr2 = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

        public static int ArrSum(int[] arr)
        {
            int sum = 0;
            foreach (int e in arr)
            {
                sum += e;
            }
            return sum;
        }
        public static void SetSum1()
        {
            _sum1 = _arr1.Sum();
        }
        public static void SetSum2()
        {
            _sum2 = _arr2.Sum();
        }
        static void Main(string[] args)
        {
            int res = ArrSum(_arr1) + ArrSum(_arr2);
            Console.WriteLine($"Метод 1 = {res}");
            Thread t1 = new Thread(SetSum1);
            Thread t2 = new Thread(SetSum2);

            t1.Start();
            t2.Start();
            t1.Join(1000);
            t2.Join(1000);
            Console.WriteLine($"sum1 = {_sum1}, sum2 = {_sum2}, Общая сумма = {_sum1 + _sum2}");

            int result1 = 0;
            int result2 = 0;
            Thread newThread1 = new Thread(() => { result1 = SetSum3(_arr1); });
            Thread newThread2 = new Thread(() => { result2 = SetSum3(_arr2); });
            newThread1.Start();
            newThread2.Start();
            newThread1.Join(1000);
            newThread2.Join(1000);
            Console.WriteLine($"{result1} + {result2} = {result1 + result2}");
        }
        public static int SetSum3(int[] arr)
        {
           return arr.Sum();
        }
    }
}
