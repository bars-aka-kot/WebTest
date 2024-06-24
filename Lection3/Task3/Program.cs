namespace Task3
{
    class Program
    {
        static int GetValue1()
        {
            Thread.Sleep(1000);
            return 1;
        }
        static int GetValue2()
        {
            Thread.Sleep(2000);
            return 2;
        }
        static void Main(string[] args)
        {
            Task<int> v1 = Task.Run(GetValue1);
            Task<int> v2 = Task.Run(GetValue2);

            v1.Wait();
            v2.Wait();
            Console.WriteLine(v1.Result + v2.Result);
        }
    }
}
