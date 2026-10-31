using System;
using System.Collections.Generic;

namespace Task28_Points
{
    class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool Equals(Point other)
        {
            if (other == null)
                return false;

            return X == other.X && Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(3, 5);
            Point point2 = new Point(3, 5);
            Point point3 = new Point(7, 2);
            Console.WriteLine("Точка 1: " + point1);
            Console.WriteLine("Точка 2: " + point2);
            Console.WriteLine("Точка 3: " + point3);
            Console.WriteLine("\nТочка 1 равна точке 2: " +
                point1.Equals(point2));
            Console.WriteLine("Точка 1 равна точке 3: " +
                point1.Equals(point3));
            HashSet<Point> points = new HashSet<Point>();
            points.Add(point1);
            points.Add(point2); 
            points.Add(point3);
            Console.WriteLine("\nКоличество точек в HashSet: " +
                points.Count);
            Console.WriteLine("Точки в HashSet:");
            foreach (Point point in points)
            {
                Console.WriteLine(point);
            }
            Console.ReadKey();
        }
    }
}
