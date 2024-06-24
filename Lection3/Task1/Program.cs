namespace Task1
{
    internal class Program
    {
        static object lockobj = new object();

        static void Print()
        {
            lock (lockobj)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.GetHashCode()}:{i}");
                }
            }
        }
        static void Main(string[] args)
        {
            for(int i = 0;i < 10; i++)
            {
                //var t = new Task(Print);
                //t.Start();
                //Можно по другому
                Task.Run(Print);
            }
            Console.ReadKey();
        }
    }
}
