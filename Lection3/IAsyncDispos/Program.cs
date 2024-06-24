namespace IAsyncDispos
{
    class DisposableAsync : IDisposable, IAsyncDisposable
    {
        private bool disposeValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposeValue)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing");
                }
                disposeValue = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Delay(100);
            Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static async Task Example()
        {
            await using(var da = new DisposableAsync())
            {
                Console.WriteLine("Using DisposableAsync");
            }
            Console.WriteLine("Destroyed DisposableAsync");
        }
        static async Task Main(string[] args)
        {
            var task = Example();
            Console.WriteLine("Control's back to method Main");
            await task;
        }
    }
}
