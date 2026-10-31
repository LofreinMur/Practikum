using System;
using System.Collections.Generic;
namespace Task27_Students
{
    class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }
        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }
        public int CompareTo(Student other)
        {
            if (other == null)
                return 1;

            return other.AverageGrade.CompareTo(AverageGrade);
        }
        public override string ToString()
        {
            return $"{Name} — средний балл: {AverageGrade:F1}";
        }
    }
    class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student student1, Student student2)
        {
            if (student1 == null && student2 == null)
                return 0;
            if (student1 == null)
                return -1;
            if (student2 == null)
                return 1;
            return string.Compare(
                student1.Name,
                student2.Name,
                StringComparison.OrdinalIgnoreCase);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Анна", 4.8),
                new Student("Иван", 3.9),
                new Student("Мария", 5.0),
                new Student("Пётр", 4.2),
                new Student("Ольга", 4.6)
            };

            Console.WriteLine("Исходный список студентов:");

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            students.Sort();
            Console.WriteLine("\nСортировка по среднему баллу (по убыванию):");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            students.Sort(new ByNameComparer());
            Console.WriteLine("\nСортировка по имени:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.ReadKey();
        }
    }
}
