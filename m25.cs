
using System;
using System.Collections.Generic;

namespace Task25_Shapes
{ 
    interface IShape
    {
        double Area();
        double Perimeter();
    }
    class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Круг (радиус {Radius})";
        }
    }
    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Area()
        {
            return Width * Height;
        }
        public double Perimeter()
        {
            return 2 * (Width + Height);
        }
        public override string ToString()
        {
            return $"Прямоугольник ({Width} x {Height})";
        }
    }
    class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Некорректные стороны треугольника.");
            }
            A = a;
            B = b;
            C = c;
        }
        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public double Perimeter()
        {
            return A + B + C;
        }
        public override string ToString()
        {
            return $"Треугольник ({A}, {B}, {C})";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(3),
                new Rectangle(4, 5),
                new Triangle(3, 4, 5),
                new Circle(2),
                new Rectangle(2, 3),
                new Triangle(5, 5, 6)
            };
            Console.WriteLine("Фигуры до сортировки:");
            foreach (IShape shape in shapes)
            {
                Console.WriteLine(
                    $"{shape} | Площадь: {shape.Area():F2} | Периметр: {shape.Perimeter():F2}");
            }
            shapes.Sort((shape1, shape2) =>
                shape1.Area().CompareTo(shape2.Area()));
            Console.WriteLine("\nФигуры после сортировки по площади:");
            foreach (IShape shape in shapes)
            {
                Console.WriteLine(
                    $"{shape} | Площадь: {shape.Area():F2} | Периметр: {shape.Perimeter():F2}");
            }
            Console.ReadKey();
        }
    }
}
