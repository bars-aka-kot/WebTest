namespace TDataSlot
{
    internal class Program
    {
        //[ThreadStatic]
        //int a = 0;
        static LocalDataStoreSlot localDataStoreSlot = Thread.AllocateDataSlot();
        // Если использовать вместо LocalDataStoreSlot просто переменную, то потоки будут записывать данные по 
        // принципу "Кто успел, тот и съел".
        // Но используя аргумент ThreadStatic, потоки снова будут использовать каждый свою переменную
        static void ThreadProc(int x)
        {
            for (int i = 0; i < 10; i++) 
            { 
                var data = ((int?)Thread.GetData(localDataStoreSlot))??0;
                Thread.SetData(localDataStoreSlot, data + x);
            }
            Console.WriteLine($"Total{x} = " + (((int?)Thread.GetData(localDataStoreSlot)) ?? 0));
        }
        static void Main(string[] args)
        {
            new Thread(() => { ThreadProc(1); }).Start();
            new Thread(() => { ThreadProc(10); }).Start();
        }
    }
}
