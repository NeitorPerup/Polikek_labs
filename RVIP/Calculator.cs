using System.Threading;
using System.Threading.Tasks;

namespace RVIP
{
    public class Calculator
    {
        public static int GetMaxAboveMainDiagonal(int[,] matrix, int minValue, int len)
        {
            int max = minValue - 1;

            for (int i = 0; i < len; ++i)
            {
                for (int j = i + 1; j < len; ++j)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
            }
            return max;
        }

        public static int GetMaxAboveMainDiagonalThread(int[,] matrix, int minValue, int len)
        { 
            int max = minValue - 1;
            object locker = new object();

            int threadNumber = 2;
            Thread[] threads = new Thread[threadNumber];
            for (int i = 0; i < threadNumber; ++i)
            {
                int start = i * len / threadNumber;
                int end = (i + 1) * len / threadNumber; 
                threads[i] = new Thread(
                    () => GetMaxForThread(matrix, start, end, len, ref locker, ref max));
                threads[i].Start();
            }

            for (int i = 0; i < threadNumber; ++i)
            {
                // ждем выполнения всех потоков
                threads[i].Join();
            }

            return max;
        }

        public static int GetMaxAboveMainDiagonalTask(int[,] matrix, int minValue, int len)
        {
            int max = minValue - 1;
            int taskNumber = 15;
            Task<int>[] tasks = new Task<int>[taskNumber];

            for (int i = 0; i < taskNumber; ++i)
            {
                int start = i * len / taskNumber;
                int end = (i + 1) * len / taskNumber;
                tasks[i] = new Task<int>(
                    () => GetMaxForTask(matrix, start, end, len, max));
                tasks[i].Start();
            }

            Task.WaitAll(tasks);

            int[] results = new int[taskNumber];
            for (int i = 0; i < taskNumber; ++i)
                results[i] = tasks[i].Result;

            return GetMax(results);
        }

        private static void GetMaxForThread(int [,] matrix, int start, int endI, int endJ, ref object locker, ref int max)
        {
            for (int i = start; i < endI; ++i)
            {
                for (int j = i + 1; j < endJ; ++j)
                {
                    lock (locker)
                    {
                        if (matrix[i, j] > max)
                            max = matrix[i, j];
                    }
                }
            }
        }

        private static int GetMaxForTask(int [,] matrix, int start, int endI, int endJ, int max)
        {
            for (int i = start; i < endI; ++i)
            {
                for (int j = i + 1; j < endJ; ++j)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
            }
            return max;
        }

        private static int GetMax(params int[] values)
        {
            int len = values.Length;
            if (len == 0)
                return -1;

            int max = values[0];

            for (int i = 1; i < len; ++i)
            {
                if (values[i] > max)
                    max = values[i];
            }
            return max;
        }
    }
}
