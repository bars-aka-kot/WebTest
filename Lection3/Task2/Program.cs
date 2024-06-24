namespace Task2
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
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(Print));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
