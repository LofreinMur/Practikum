using System;

namespace Task23_Nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? age = 20;
            int? emptyAge = null;

            Console.WriteLine("Возраст: " + age);
            Console.WriteLine("Пустой возраст: " + emptyAge);
            int result = emptyAge ?? 0;
            Console.WriteLine("Возраст с учётом значения по умолчанию: " + result);
            string name = null;
            Console.WriteLine("Длина имени: " + (name?.Length));
            name = "Александра";
            Console.WriteLine("Длина имени после присваивания: " + (name?.Length));
            Console.ReadKey();
        }
    }
}
