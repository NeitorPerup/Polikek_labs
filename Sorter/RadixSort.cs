using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorter
{
    // поразрядная сортировка. Сложность rang * n, память rang + n
    internal class RadixSort
    {
        public static void Sort(int[] arr)
        {
            int rang = 10; // количество цифр
            int len = arr.ToList().Max(x => Math.Abs(x)).ToString().Length; // число с наибольшим количеством цифр
            int n = arr.Length; // длина массива

            var list = new Dictionary<int, List<int>>(); // 
            for (int i = 0; i < len; ++i)
            {
                // иницилизируем список
                for (int j = 0; j < rang; ++j)
                    list[j] = new List<int>();

                // заполняем список
                for (int k = 0; k < n; ++k)
                {
                    //int digit = Math.Abs(arr[k] % (int)Math.Pow(rang, i + 1)); // берем разряд числа по которому сортируем
                    int digit = arr[k] / (int)Math.Pow(rang, i) % 10; // берем разряд числа по которому сортируем
                    if (list.ContainsKey(digit))
                        list[digit].Add(arr[k]);
                    else
                        list[digit] = new List<int> { arr[k] };
                }

                // перезаписываем массив
                for (int k = 0, ind = 0; k < rang; ++k)
                {
                    if (list.ContainsKey(k) is false)
                        continue;

                    var rangList = list[k]; // список чисел с цифрой k
                    foreach (var item in rangList)
                    {
                        arr[ind] = item;
                        ind++;
                    }
                }
            }
        }
    }
}
