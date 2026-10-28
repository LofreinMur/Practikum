using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine() ?? "";
        string reversed = ReverseString(text);
        Console.WriteLine("Перевёрнутая строка: " + reversed);
    }

    static string ReverseString(string text)
    {
        string result = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            result += text[i];
        }
        return result;
    }
}
