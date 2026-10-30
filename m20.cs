using System;

namespace Task20_Generics
{
    internal class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) >= 0)
                return a;

            return b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 20 ===");
            Console.WriteLine("\n--- Тип int ---");
            int a = 10;
            int b = 20;
            Console.WriteLine("До Swap: a = " + a + ", b = " + b);
            Swap(ref a, ref b);
            Console.WriteLine("После Swap: a = " + a + ", b = " + b);
            Console.WriteLine("Max: " + Max(a, b));
            Console.WriteLine("\n--- Тип string ---");
            string first = "Анна";
            string second = "Мария";
            Console.WriteLine("До Swap: first = " + first + ", second = " + second);
            Swap(ref first, ref second);
            Console.WriteLine("После Swap: first = " + first + ", second = " + second);
            Console.WriteLine("Max: " + Max(first, second));
            Console.WriteLine("\n--- Тип double ---");
            double x = 15.5;
            double y = 25.7;
            Console.WriteLine("До Swap: x = " + x + ", y = " + y);
            Swap(ref x, ref y);
            Console.WriteLine("После Swap: x = " + x + ", y = " + y);
            Console.WriteLine("Max: " + Max(x, y));
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
