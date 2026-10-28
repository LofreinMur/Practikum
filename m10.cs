using System;
using System.Diagnostics;

class Program
{  static void Main()
    {
        const int size = 10000;
        int[] numbers = new int[size];
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 100001);
        }
        int[] bubbleArray = (int[])numbers.Clone();
        int[] insertionArray = (int[])numbers.Clone();
        Stopwatch stopwatch = Stopwatch.StartNew();
        BubbleSort(bubbleArray);
        stopwatch.Stop();
        long bubbleTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Restart();
        InsertionSort(insertionArray);
        stopwatch.Stop();
        long insertionTime = stopwatch.ElapsedMilliseconds;
        Console.WriteLine("Сортировка массива из 10 000 элементов");
        Console.WriteLine();
        Console.WriteLine("Пузырьковая сортировка: " + bubbleTime + " мс");
        Console.WriteLine("Сортировка вставками: " + insertionTime + " мс");
        Console.WriteLine();
        if (ArraysEqual(bubbleArray, insertionArray))
        {
            Console.WriteLine("Результат: массивы отсортированы одинаково.");
        }
        else
        {
            Console.WriteLine("Ошибка: результаты сортировки отличаются.");
        }

        Console.WriteLine("Первые 10 элементов:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(bubbleArray[i] + " ");
        }

        Console.WriteLine();
    }
    static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
    }
    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
    static bool ArraysEqual(int[] first, int[] second)
    {
        if (first.Length != second.Length)
        {
            return false;
        }

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                return false;
            }
        }
        return true;
    }
}