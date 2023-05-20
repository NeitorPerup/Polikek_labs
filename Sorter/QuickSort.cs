using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    internal class QuickSort
    {
        public static void Sort(int[] arr, int l, int r)
        {
            if (l >= r)
                return;

            int ind = InternalSort(arr, l, r);
            Sort(arr, l, ind);
            Sort(arr, ind + 1, r);
        }

        private static int InternalSort(int[] arr, int l, int r)
        {
            int elem = arr[new Random().Next(l, r + 1)];
            int i = l, j = r;

            while (i <= j)
            {
                while (arr[i] < elem)
                    ++i;
                while (arr[j] > elem)
                    --j;
                if (i >= j)
                    break;

                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;

                if (arr[i] == arr[j])
                    --j;
            }

            return j;
        }
    }
}
