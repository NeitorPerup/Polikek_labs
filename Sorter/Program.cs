using System;

namespace Sorter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // поразрядная, подсчетом
            // слиянием, быстрая
            // гномья га га га

            var a = RandomArray(15, -100, 100);
            PrintArray(a, "Not sorted");

            //QuickSort.Sort(a, 0, a.Length - 1); // быстрая сортировка
            //RadixSort.Sort(a); // поразрядная сортировка, только положительные числа
            //CountingSort.Sort(a); // сортировка подсчетом, только положительные числа
            //GnomeSort.Sort(a); // имба
            MergeSort.Sort(a, 0, a.Length - 1);

            PrintArray(a, "Sorted");
            Console.ReadKey();
        }

        static int[] RandomArray(int length, int min = 0, int max = Int32.MaxValue)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        static void PrintArray(int[] array, string message = "")
        {
            Console.WriteLine(message);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
