using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static List<int> FindDuplicatesHashSet(List<int> numbers)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();

        foreach (int number in numbers)
        {
            if (uniqueNumbers.Contains(number))
            {
                duplicates.Add(number);
            }
            else
            {
                uniqueNumbers.Add(number);
            }
        }

        return duplicates.OrderBy(x => x).ToList();
    }
    static List<int> FindDuplicatesLINQ(List<int> numbers)
    {
        return numbers
            .GroupBy(x => x)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .OrderBy(x => x)
            .ToList();
    }
    static void Main()
    {
        List<int> numbers = new List<int>
        {
            1, 5, 3, 7, 5, 2, 3, 8, 1, 9, 5, 10
        };
        Console.WriteLine("Исходный список:");
        Console.WriteLine(string.Join(", ", numbers));
        List<int> result1 = FindDuplicatesHashSet(numbers);
        Console.WriteLine("\nДубликаты через HashSet:");
        Console.WriteLine(string.Join(", ", result1));
        List<int> result2 = FindDuplicatesLINQ(numbers);
        Console.WriteLine("\nДубликаты через LINQ:");
        Console.WriteLine(string.Join(", ", result2));
        bool isEqual = result1.SequenceEqual(result2);
        Console.WriteLine("\nРезультаты совпадают: " + isEqual);
    }
}