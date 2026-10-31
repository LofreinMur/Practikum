using System;
class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}

class Program
{
    static void Process(string type)
    {
        switch (type)
        {
            case "format":
                throw new FormatException("Ошибка формата данных");
            case "divide":
                throw new DivideByZeroException("Деление на ноль");
            case "custom":
                throw new CustomException("Пользовательская ошибка");
            default:
                Console.WriteLine("Операция выполнена успешно");
                break;
        }
    }
    static void Main()
    {
        string[] errors = { "format", "divide", "custom", "success" };
        foreach (string error in errors)
        {
            Console.WriteLine();
            Console.WriteLine($"Проверка: {error}");
            try
            {
                Process(error);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка формата: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка деления: {ex.Message}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Пользовательская ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершено");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Программа завершена.");
        Console.ReadKey();
    }
}