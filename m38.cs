using System;
using System.Collections.Generic;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        const int elementCount = 100000;
        const int insertCount = 1000;
        List<int> list = new List<int>();
        for (int i = 0; i < elementCount; i++)
        {
            list.Add(i);
        }
        LinkedList<int> linkedList = new LinkedList<int>();

        for (int i = 0; i < elementCount; i++)
        {
            linkedList.AddLast(i);
        }
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        for (int i = 0; i < insertCount; i++)
        {
            int middle = list.Count / 2;
            list.Insert(middle, -i);
        }
        stopwatch1.Stop();
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        LinkedListNode<int> middleNode = linkedList.First;
        for (int i = 0; i < elementCount / 2; i++)
        {
            middleNode = middleNode.Next;
        }

        for (int i = 0; i < insertCount; i++)
        {
            linkedList.AddBefore(middleNode, -i);
        }
        stopwatch2.Stop();
        Console.WriteLine("Количество исходных элементов: " + elementCount);
        Console.WriteLine("Количество вставок: " + insertCount);
        Console.WriteLine("\nВремя вставки в List:");
        Console.WriteLine(stopwatch1.ElapsedMilliseconds + " мс");
        Console.WriteLine("\nВремя вставки в LinkedList:");
        Console.WriteLine(stopwatch2.ElapsedMilliseconds + " мс");
        Console.WriteLine("\nКоличество элементов после вставки:");
        Console.WriteLine("List: " + list.Count);
        Console.WriteLine("LinkedList: " + linkedList.Count);
    }
}