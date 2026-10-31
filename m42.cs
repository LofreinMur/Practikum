using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task LongOperationAsync(CancellationToken token)
    {
        Console.WriteLine("Операция началась.");
        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(500, token);
            Console.WriteLine($"Выполнен шаг {i} из 10");
        }
        Console.WriteLine("Операция успешно завершена.");
    }
    static async Task Main()
    {
        using (CancellationTokenSource cts =
               new CancellationTokenSource())
        {
            Task operation = LongOperationAsync(cts.Token);
            await Task.Delay(2000);
            Console.WriteLine();
            Console.WriteLine("Отправлен запрос на отмену...");
            cts.Cancel();
            try
            {
                await operation;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция отменена.");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Программа завершена.");
        Console.ReadKey();
    }
}