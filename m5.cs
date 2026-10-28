using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("ТАБЛИЦА УМНОЖЕНИЯ 1 --- 10");
        Console.WriteLine();
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }
}
