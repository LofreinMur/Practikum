using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine() ?? "";

        if (IsPalindrome(text))
        {
            Console.WriteLine("Это палиндром.");
        }
        else
        {
            Console.WriteLine("Это не палиндром.");
        }
    }
    static bool IsPalindrome(string text)
    {
        StringBuilder cleaned = new StringBuilder();
        foreach (char ch in text)
        {
            if (char.IsLetterOrDigit(ch))
            {
                cleaned.Append(char.ToLowerInvariant(ch));
            }
        }

        string normalized = cleaned.ToString();
        int left = 0;
        int right = normalized.Length - 1;
        while (left < right)
        {
            if (normalized[left] != normalized[right])
            {
                return false;
            }

            left++;
            right--;
        }
        return true;
    }
}
