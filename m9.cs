using System;
class Program
{
    static void Main()
    {
        int[] numbers = { 12, 5, 8, 23, 4, 16, 9 };

        if (numbers.Length == 0)
        {
            Console.WriteLine("Массив пуст");
            return;
        }
        Console.WriteLine("Элементы массива: " + string.Join(", ", numbers));
        Console.WriteLine("Минимум: " + FindMin(numbers));
        Console.WriteLine("Максимум: " + FindMax(numbers));
        Console.WriteLine("Сумма: " + FindSum(numbers));
        Console.WriteLine("Среднее арифметическое: " + FindAverage(numbers));
    }
    static int FindMin(int[] numbers)
    {
        int min = numbers[0];

        foreach (int number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
        }

        return min;
    }

    static int FindMax(int[] numbers)
    {
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        return max;
    }
    static int FindSum(int[] numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    static double FindAverage(int[] numbers)
    {
        return (double)FindSum(numbers) / numbers.Length;
    }
}
