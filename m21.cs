using System;

namespace Task21_DayOfWeek
{
    enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    internal class Program
    {
        static bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday ||
                   day == DayOfWeek.Sunday;
        }
        static string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "Понедельник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Среда";
                case DayOfWeek.Thursday:
                    return "Четверг";
                case DayOfWeek.Friday:
                    return "Пятница";
                case DayOfWeek.Saturday:
                    return "Суббота";
                case DayOfWeek.Sunday:
                    return "Воскресенье";
                default:
                    return "Неизвестный день";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 21 ===");
            Console.WriteLine("Дни недели:\n");
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine(
                    GetRussianName(day) +
                    " — " +
                    (IsWeekend(day) ? "Выходной" : "Рабочий день")
                );
            }
            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
