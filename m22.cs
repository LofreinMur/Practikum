using System;

namespace Task22_ParamsOverload
{
    internal class Program
    {
        static int Sum(int[] numbers)
        {
            int result = 0;

            foreach (int number in numbers)
            {
                result += number;
            }

            return result;
        }

        static int Sum(int first, params int[] numbers)
        {
            int result = first;

            foreach (int number in numbers)
            {
                result += number;
            }

            return result;
        }
        static int Sum()
        {
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Сумма отдельных чисел: " + Sum(1, 2, 3));
            Console.WriteLine("Сумма массива: " + Sum(new int[] { 1, 2, 3 }));
            Console.WriteLine("Сумма без чисел: " + Sum());
            Console.ReadKey();
        }
    }
}
