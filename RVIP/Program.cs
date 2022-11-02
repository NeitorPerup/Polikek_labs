using System;
using System.Threading;

namespace RVIP
{
    // ThreadPoolExecutor - Thread
    // ForkJoinPoll - Task
    class Program
    {
        private static int MatrixLen = 15000;
        private static int MinValue = 0, MaxValue = int.MaxValue;

        static void Main(string[] args)
        {
            int[,] matrix = Helper.RandomMatrix(MatrixLen, MinValue, MaxValue);

            //ThreadCalculator threadCalculator = new ThreadCalculator(matrix, MatrixLen, 2);
            //threadCalculator.GetMaxAboveMainDiagonal(MinValue);

            //Thread.Sleep(2000);

            int max;
            TimeSpan time = Helper.GetFunctionTime(
                () => Calculator.GetMaxAboveMainDiagonal(matrix, MinValue, MatrixLen),
                out max);
            Console.WriteLine($"Однопоточный вариант алгоритма: результат = {max}, время = {time.TotalSeconds}");

            //time = Helper.GetFunctionTime(
            //    () => Calculator.GetMaxAboveMainDiagonalThread(matrix, MinValue, MatrixLen),
            //    out max);
            //Console.WriteLine($"Многопоточный вариант алгоритма(Threads): результат = {max}, время = {time.TotalSeconds}");
            

            time = Helper.GetFunctionTime(
                () => Calculator.GetMaxAboveMainDiagonalTask(matrix, MinValue, MatrixLen),
                out max);
            Console.WriteLine($"Многопоточный вариант алгоритма(Tasks): результат = {max}, время = {time.TotalSeconds}");
        }

        
    }
}
