using System.Threading.Channels;

namespace SingleTonLazy
{
    public class Singleton
    {
        private static readonly Lazy<Singleton> lazyInstance = new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        { }

        public static Singleton Instance => lazyInstance.Value;

        public void DoSomeWork() => Console.WriteLine("Working!");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.DoSomeWork();
        }
    }
}
