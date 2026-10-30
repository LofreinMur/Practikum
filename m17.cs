using System;
using System.Diagnostics;
using System.Text;

namespace Task17_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int count = 10000;
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            string result1 = "";
            for (int i = 1; i <= count; i++)
            {
                result1 += i;
            }
            stopwatch1.Stop();
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= count; i++)
            {
                builder.Append(i);
            }
            string result2 = builder.ToString();
            stopwatch2.Stop();
            Console.WriteLine("=== Задание 17 ===");
            Console.WriteLine("Количество чисел: " + count);
            Console.WriteLine("\nВремя конкатенации через +: "
                + stopwatch1.ElapsedMilliseconds + " мс");
            Console.WriteLine("Время StringBuilder: "
                + stopwatch2.ElapsedMilliseconds + " мс");
            Console.WriteLine("\nСтроки одинаковые: "
                + (result1 == result2));
            Console.WriteLine("\nРазница во времени: "
                + Math.Abs(stopwatch1.ElapsedMilliseconds -
                           stopwatch2.ElapsedMilliseconds) + " мс");
            Console.WriteLine("\nПочему StringBuilder быстрее?");
            Console.WriteLine(
                "Обычные строки неизменяемые. При использовании + " +
                "создаются новые строки. StringBuilder изменяет " +
                "внутренний буфер, поэтому работает эффективнее.");
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
