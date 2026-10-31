using System;
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i += 2)
        {
            Console.WriteLine($"Генератор: создаём число {i}");

            yield return i;
        }
    }
    static void Main()
    {
        Console.WriteLine("Чётные числа до 20:\n");

        foreach (int number in GetEvenNumbers(20))
        {
            Console.WriteLine($"Получено число: {number}");
        }
        Console.WriteLine("\nПроверка ленивого выполнения:");
        IEnumerable<int> numbers = GetEvenNumbers(6);
        Console.WriteLine("Генератор создан, но ещё не запущен.");
        foreach (int number in numbers)
        {
            Console.WriteLine($"Получено: {number}");
        }
        Console.WriteLine("\nПрограмма завершена.");
    }
}