namespace TMutex3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mtx = new Mutex(true, "Global\\MyMytex", out bool createdNew ))
            {
                if (!createdNew)
                {
                    Console.WriteLine("Повторный запуск");
                    return;
                }
                mtx.WaitOne();
                for (int i = 0; i < 100; i++) 
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
                mtx.ReleaseMutex();
                mtx.ReleaseMutex();
            }
        }
    }
}
