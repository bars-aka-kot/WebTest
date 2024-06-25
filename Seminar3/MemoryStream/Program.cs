using System.Text;

namespace MemoryStreamTest
{
    internal class Program
    {
        static async Task Main()
        {
            // Пример использования
            byte[] data = Encoding.UTF8.GetBytes("Hello, this is data for MemoryStream!");

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                await ProcessMemoryStreamAsync(memoryStream);
            }
        }

        static async Task ProcessMemoryStreamAsync(MemoryStream memoryStream)
        {
            // Асинхронное чтение из MemoryStream
            byte[] buffer = new byte[1024];
            int bytesRead=0;

            Console.WriteLine("Start reading from MemoryStream:");
            StringBuilder sb = new StringBuilder();
            while ((bytesRead = await memoryStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // Асинхронная обработка данных
                //string dataChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                //Console.Write(dataChunk);
                //await Task.Delay(100); // Имитация асинхронной обработки
            sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            await Console.Out.WriteLineAsync(sb.ToString());

            Console.WriteLine("\nReading from MemoryStream completed.");
        }
    }
}
