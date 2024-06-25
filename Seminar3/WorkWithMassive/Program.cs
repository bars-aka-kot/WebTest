namespace ChangeAndSaveMassive
{
    class Program
    {
        static async Task Main()
        {
            // Пример массива данных (может быть заменен на реальные данные)
            int[] data = { 1, 2, 3, 4, 5 };
            try
            {
                // Асинхронная обработка массива
                Task<int[]> processedDataTask = ProcessArrayAsync(data);

                // Асинхронный вывод результатов на консоль
                Console.WriteLine("\nProcessed Data:");
                int[] processedData = await processedDataTask;
                foreach (var item in processedData)
                {
                    Console.Write($"{item} ");
                }

                // Асинхронная операция после обработки массива с использованием ContinueWith
                var sumTask = processedDataTask.ContinueWith(t => ProcessSumAsync(t.Result));
                int sum = await await sumTask;
                Console.WriteLine($"\nSum of Processed Data: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        static async Task<int> ProcessSumAsync(int[] array)
        {
            await Task.Delay(100);
            return array.Sum();
        }

        static async Task<int[]> ProcessArrayAsync(int[] data)
        {
            return await Task.WhenAll(Array.ConvertAll(data, async(x) => await ProcessElementAsync(x)));
        }

        static async Task<int> ProcessElementAsync(int number)
        {
            await Task.Delay(100);
            return number * 2;
        }
    }
}
