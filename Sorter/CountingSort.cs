using System.Collections.Generic;

namespace Sorter
{
    // сортировка подсчетом, время n, память n?
    internal class CountingSort
    {
        public static void Sort(int[] arr)
        {
            int max = Max(arr);
            var helpArr = new int[max + 1];

            for (int i = 0; i < arr.Length; ++i)
            {
                helpArr[arr[i]] += 1;
            }

            int ind = 0;
            for (int i = 0; i < helpArr.Length; i++)
            {
                for (int j = 0; j < helpArr[i]; ++j)
                {
                    arr[ind] = i;
                    ind++;
                }
            }
        }

        public static int Max(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }
    }
}
