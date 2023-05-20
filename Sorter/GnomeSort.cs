namespace Sorter
{
    internal class GnomeSort
    {
        // гномья сортировка, сложность n^2
        public static void Sort(int[] arr)
        {
            int n = arr.Length; // длина массива
            int i = 1;
            while (i < n)
            {
                if (i == 0 || arr[i - 1] <= arr[i])
                    i++;
                else
                {
                    int tmp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = tmp;
                    i--;
                }
            }
        }
    }
}
