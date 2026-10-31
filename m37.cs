using System;
using System.Collections.Generic;
using System.Diagnostics;
class Program
{
    static long Fibonacci(int n)
    {
        if (n <= 1)
            return n;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
    static Dictionary<int, long> memo = new Dictionary<int, long>();
    static long FibonacciMemo(int n)
    {
        if (n <= 1)
            return n;
        if (memo.ContainsKey(n))
            return memo[n];
        long result = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
        memo[n] = result;
        return result;
    }
    static void Main()
    {
        int n = 35;
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        long result1 = Fibonacci(n);
        stopwatch1.Stop();
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        long result2 = FibonacciMemo(n);
        stopwatch2.Stop();
        Console.WriteLine("Число N: " + n);
        Console.WriteLine("\nОбычная рекурсия:");
        Console.WriteLine("Результат: " + result1);
        Console.WriteLine("Время: " + stopwatch1.ElapsedMilliseconds + " мс");
        Console.WriteLine("\nМемоизация через Dictionary:");
        Console.WriteLine("Результат: " + result2);
        Console.WriteLine("Время: " + stopwatch2.ElapsedMilliseconds + " мс");
        Console.WriteLine("\nРазница во времени: " +
            (stopwatch1.ElapsedMilliseconds - stopwatch2.ElapsedMilliseconds) +
            " мс");
        Console.WriteLine("\nРезультаты совпадают: " + (result1 == result2));
    }
}