using System;
namespace Task18_TryParse
{
    internal class Program
    {
        static bool TryParseNumber(string text, out int number)
        {
            return int.TryParse(text, out number);
        }
        static bool ParseNumber(string text, out int number)
        {
            try
            {
                number = int.Parse(text);
                return true;
            }
            catch (FormatException)
            {
                number = 0;
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 18 ===");
            string[] testValues = { "123", "abc" };
            foreach (string value in testValues)
            {
                Console.WriteLine("\nВведённое значение: " + value);
                if (TryParseNumber(value, out int number1))
                {
                    Console.WriteLine("TryParse: успешно, число = " + number1);
                }
                else
                {
                    Console.WriteLine("TryParse: ошибка преобразования");
                }
                if (ParseNumber(value, out int number2))
                {
                    Console.WriteLine("Parse + try/catch: успешно, число = " + number2);
                }
                else
                {
                    Console.WriteLine("Parse + try/catch: ошибка преобразования");
                }
            }
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
