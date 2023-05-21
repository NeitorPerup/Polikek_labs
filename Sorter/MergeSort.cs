using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    // сортировка слиянием, сложность nlogn, дополнительная память n
    internal class MergeSort
    {
        public static void Sort(int[] arr, int l, int r)
        {
            if (l >= r)
                return;

            int middle = (l + r) / 2;
            Sort(arr, l, middle);
            Sort(arr, middle + 1, r);
            Merge(arr, l, middle, r);
        }

        private static void Merge(int[] arr, int l, int split, int r)
        {
            int i = l; // для левой части массива
            int j = split + 1; // для правой части массива

            int n = r - l + 1; // количество элементов в массиве
            int[] tmp = new int[n];
            int tmpInd = 0;

            while (tmpInd < n)
            {
                // если второй массив закончился или элемент меньше и первый массив не закончился
                if ((j == r + 1 || arr[i] <= arr[j]) && i != split + 1)
                    tmp[tmpInd++] = arr[i++];
                // если первый массив закончился или элемент меньше и второй массив не закончился
                else if ((i == split + 1 || arr[j] < arr[i]) && j != r + 1)
                    tmp[tmpInd++] = arr[j++];
            }

            // идет слияние, пока есть хоть один элемент в каждой последовательности
            //while (i <= split && j <= r)
            //{
            //    if (arr[i] < arr[j])
            //        tmp[tmpInd++] = arr[i++];
            //    else
            //        tmp[tmpInd++] = arr[j++];
            //}

            //// одна последовательность закончилась - 
            //// копировать остаток другой в конец буфера 
            //while (j <= r)   // пока вторая последовательность непуста 
            //    tmp[tmpInd++] = arr[j++];
            //while (i <= split)  // пока первая последовательность непуста
            //    tmp[tmpInd++] = arr[i++];

            for (int k = 0; k < n; ++k)
            {
                arr[l + k] = tmp[k];
            }
        }
    }
}
