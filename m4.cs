using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        if (!double.TryParse(Console.ReadLine(), out double number1))
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
            return;
        }
        Console.Write("Введите операцию (+, -, *, /): ");
        string operation = Console.ReadLine() ?? "";
        Console.Write("Введите второе число: ");
        if (!double.TryParse(Console.ReadLine(), out double number2))
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
            return;
        }
        double result;
        switch (operation)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                if (number2 == 0)
                {
                    Console.WriteLine("Ошибка: делить на ноль нельзя!");
                    return;
                }
                result = number1 / number2;
                break;
            default:
                Console.WriteLine("Неизвестная операция.");
                return;
        }

        Console.WriteLine("Результат: " + result);
    }
}
