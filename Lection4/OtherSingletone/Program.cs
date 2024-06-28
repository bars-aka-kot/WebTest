namespace OtherSingletone
{
    public class Singleton
    {
        private static Singleton? instance;
        private static readonly object locObject = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
        public void DoSomeThing()
        {
            Console.WriteLine("Hi! I'm Singleton");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.DoSomeThing();       
        }
    }
}
