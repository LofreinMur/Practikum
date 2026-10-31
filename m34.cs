using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<string> words = new List<string>
        {
            "яблоко",
            "апельсин",
            "арбуз",
            "банан",
            "берёза",
            "вишня",
            "виноград",
            "груша",
            "дыня",
            "дом",
            "ежевика",
            "клубника"
        };
        var groups = words
            .GroupBy(word => char.ToLower(word[0]))
            .OrderBy(group => group.Key);
        Console.WriteLine("Группировка слов по первой букве:\n");
        foreach (var group in groups)
        {
            var sortedWords = group.OrderBy(word => word);
            Console.WriteLine(
                $"{char.ToUpper(group.Key)}: {string.Join(", ", sortedWords)}"
            );
        }
    }
}