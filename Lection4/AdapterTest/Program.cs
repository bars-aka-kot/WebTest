namespace AdapterTest
{
    class LegacyLibrary
    {
        public void SpecFicRequest()
        {
            Console.WriteLine("I'm old, but i'm superstar");
        }
    }
    interface ITarget
    {
        void Request();
    }
    class Adapter : ITarget
    {
        private LegacyLibrary _library;
        public Adapter(LegacyLibrary library)
        {
            this._library = library;
        }
        public void Request()
        {
            _library.SpecFicRequest();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LegacyLibrary library = new LegacyLibrary();
            ITarget target = new Adapter(library);
            target.Request();
        }
    }
}
