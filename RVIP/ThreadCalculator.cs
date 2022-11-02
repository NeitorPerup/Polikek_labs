using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RVIP
{
    public class ThreadCalculator
    {
        private readonly int ThreadCount;
        private int[,] Matrix;
        private object Locker = new object();
        private int MaxValue, MatrixLen;
        private int ThreadCounter = 0;
        private Stopwatch Sw = new Stopwatch();

        public ThreadCalculator(int[,] matrix, int matrixLen, int threadCount)
        {
            Matrix = matrix;
            MatrixLen = matrixLen;
            ThreadCount = threadCount;
        }

        public int GetMaxAboveMainDiagonal(int minValue)
        {
            Sw.Start();
            int max = minValue - 1;

            Thread[] threads = new Thread[ThreadCount];
            for (int i = 0; i < ThreadCount; ++i)
            {
                int start = i * MatrixLen / ThreadCount;
                int end = (i + 1) * MatrixLen / ThreadCount;
                threads[i] = new Thread(
                    () => GetMaxForThread(start, end, MatrixLen));
                threads[i].Start();
            }

            return max;
        }

        private void GetMaxForThread( int start, int endI, int endJ)
        {
            for (int i = start; i < endI; ++i)
            {
                for (int j = i + 1; j < endJ; ++j)
                {
                    lock (Locker)
                    {
                        if (Matrix[i, j] > MaxValue)
                            MaxValue = Matrix[i, j];
                    }
                }
            }
            GetTime();
        }

        private void GetTime()
        {
            lock (Locker)
            {
                ThreadCounter += 1;
                if (ThreadCounter == ThreadCount)
                {
                    Sw.Stop();
                    Console.WriteLine($"Многопоточный вариант алгоритма(Threads): результат = {MaxValue}, время = {Sw.Elapsed.TotalSeconds}");
                }
            }
        }
    }
}
