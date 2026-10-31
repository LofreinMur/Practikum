using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }
    static async Task Main()
    {
        Console.WriteLine("Задание 41 — Task.WhenAll");
        Console.WriteLine();
        Console.WriteLine("Последовательное выполнение:");
        Stopwatch sequentialWatch = Stopwatch.StartNew();
        int[] sequentialResults = new int[10];
        for (int i = 0; i < 10; i++)
        {
            sequentialResults[i] = await WorkAsync(i + 1);
            Console.WriteLine($"Задача {i + 1} завершена");
        }
        sequentialWatch.Stop();
        Console.WriteLine(
            $"Время последовательного выполнения: {sequentialWatch.ElapsedMilliseconds} мс");
        Console.WriteLine();
        Console.WriteLine("Параллельное выполнение:");
        Stopwatch parallelWatch = Stopwatch.StartNew();
        Task<int>[] tasks = new Task<int>[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = WorkAsync(i + 1);
        }
        int[] parallelResults = await Task.WhenAll(tasks);
        parallelWatch.Stop();
        Console.WriteLine("Все задачи завершены");
        Console.WriteLine(
            $"Время параллельного выполнения: {parallelWatch.ElapsedMilliseconds} мс");
        Console.WriteLine();
        Console.WriteLine("Результаты последовательного выполнения:");
        Console.WriteLine(string.Join(", ", sequentialResults));
        Console.WriteLine("Результаты параллельного выполнения:");
        Console.WriteLine(string.Join(", ", parallelResults));
        Console.WriteLine();
        Console.WriteLine(
            "Результаты совпадают: " +
            sequentialResults.SequenceEqual(parallelResults));
        Console.ReadKey();
    }
}