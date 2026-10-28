
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Привет! Это моё первое задание на C#.");

        string today = DateTime.Now.ToString("dd.MM.yyyy");

        Console.WriteLine("Сегодня: " + today);
    }
}
