using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите целое число: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Ошибка: некорректное число.");
            return;
        }
        int sum1 = SumDigitsString(number);
        int sum2 = SumDigitsMath(number);

        Console.WriteLine("Сумма цифр через строку: " + sum1);
        Console.WriteLine("Сумма цифр арифметически: " + sum2);
    }
    static int SumDigitsString(int number)
    {
        string text = Math.Abs((long)number).ToString();
        int sum = 0;
        foreach (char digit in text)
        {
            sum += digit - '0';
        }
        return sum;
    }
    static int SumDigitsMath(int number)
    {
        long n = Math.Abs((long)number);
        int sum = 0;
        while (n > 0)
        {
            sum += (int)(n % 10);
            n /= 10;
        }
        return sum;
    }
}
