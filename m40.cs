using System;
using System.Threading.Tasks;
class Program
{
    static async Task<string> DownloadAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL не может быть пустым!");
        }
        Console.WriteLine($"Начинаем скачивание: {url}");
        await Task.Delay(1000);
        return $"Файл с адреса {url} успешно скачан!";
    }
    static async Task Main(string[] args)
    {
        Console.WriteLine("Асинхронное скачивание файлов\n");
        try
        {
            string result = await DownloadAsync("https://example.com/file.zip");
            Console.WriteLine(result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        try
        {
            string result = await DownloadAsync("");
            Console.WriteLine(result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        Console.WriteLine("\nПрограмма завершена.");
    }
}