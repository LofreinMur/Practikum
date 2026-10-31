using System;
using System.Collections.Generic;
using System.Linq;
class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public Employee(string name, int age, decimal salary, string department)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Department = department;
    }
}
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Иван", 25, 50000, "IT"),
            new Employee("Мария", 32, 75000, "Бухгалтерия"),
            new Employee("Алексей", 41, 90000, "IT"),
            new Employee("Ольга", 29, 60000, "Продажи"),
            new Employee("Дмитрий", 35, 85000, "IT"),
            new Employee("Анна", 27, 55000, "Бухгалтерия"),
            new Employee("Сергей", 45, 95000, "Продажи"),
            new Employee("Елена", 38, 70000, "Бухгалтерия"),
            new Employee("Павел", 31, 65000, "IT"),
            new Employee("Наталья", 23, 48000, "Продажи")
        };
        Console.WriteLine("Топ-3 сотрудников по зарплате:");
        var topEmployees = employees
            .OrderByDescending(e => e.Salary)
            .Take(3);
        foreach (var employee in topEmployees)
        {
            Console.WriteLine(
                $"{employee.Name} — {employee.Salary} руб."
            );
        }
        Console.WriteLine("\nСредняя зарплата по отделам:");
        var averageSalaries = employees
            .GroupBy(e => e.Department)
            .Select(group => new
            {
                Department = group.Key,
                AverageSalary = group.Average(e => e.Salary)
            });

        foreach (var department in averageSalaries)
        {
            Console.WriteLine(
                $"{department.Department}: {department.AverageSalary:F2} руб."
            );
        }
        Console.WriteLine("\nСотрудники старше 30 лет:");
        var olderEmployees = employees
            .Where(e => e.Age > 30);
        foreach (var employee in olderEmployees)
        {
            Console.WriteLine(
                $"{employee.Name}, возраст: {employee.Age}"
            );
        }
    }
}