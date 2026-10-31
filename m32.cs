using System;
class Temperature
{
    private double celsius;
    public double Celsius
    {
        get
        {
            return celsius;
        }
        set
        {
            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Температура не может быть ниже абсолютного нуля (-273.15 °C)."
                );
            }
            celsius = value;
        }
    }
    public double Fahrenheit
    {
        get
        {
            return Celsius * 9 / 5 + 32;
        }
    }
}
class Program
{
    static void Main()
    {
        Temperature temperature = new Temperature();
        temperature.Celsius = 25;
        Console.WriteLine("Температура в Цельсиях: " +
                          temperature.Celsius + " °C");
        Console.WriteLine("Температура в Фаренгейтах: " +
                          temperature.Fahrenheit + " °F");
        try
        {
            temperature.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("\nОшибка: " + ex.Message);
        }
    }
}