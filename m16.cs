
using System;

namespace Task16_StringExtensions
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            string cleaned = "";

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                    cleaned += char.ToLower(c);
            }

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            string[] words = text.Split(
                new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            );

            return words.Length;
        }
        public static string ReverseString(this string text)
        {
            if (text == null)
                return "";

            char[] chars = text.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = "А роза упала на лапу Азора";
            string text2 = "Привет мир";
            string text3 = "Hello";
            Console.WriteLine("=== Задание 16 ===");
            Console.WriteLine("\nСтрока: " + text1);
            Console.WriteLine("Палиндром: " + text1.IsPalindrome());
            Console.WriteLine("\nСтрока: " + text2);
            Console.WriteLine("Количество слов: " + text2.WordCount());
            Console.WriteLine("Перевёрнутая строка: " + text2.ReverseString());
            Console.WriteLine("\nСтрока: " + text3);
            Console.WriteLine("Палиндром: " + text3.IsPalindrome());
            Console.WriteLine("Количество слов: " + text3.WordCount());
            Console.WriteLine("Перевёрнутая строка: " + text3.ReverseString());
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
