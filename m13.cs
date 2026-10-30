using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
  static void Main()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine() ?? "";
        text = text.ToLowerInvariant();
        string[] words = Regex.Split(text, @"[^\p{L}\p{N}]+");
        Dictionary<string, int> wordCount =
            new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                continue;
            }
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }
        var sortedWords = wordCount
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key);
        Console.WriteLine("\nЧастота слов:");
        foreach (var pair in sortedWords)
        {
            Console.WriteLine($"{pair.Key} — {pair.Value}");
        }
    }
}
