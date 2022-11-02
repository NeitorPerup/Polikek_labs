using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RVIP
{
    public class Helper
    {
        public static int[,] RandomMatrix(int n, int minValue, int maxValue)
        {
            Random rand = new Random(12345);
            int[,] res = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    res[i, j] = rand.Next(minValue, maxValue);
                }
            }

            return res;
        }

        public static TimeSpan GetFunctionTime(Func<int> func, out int res)
        {
            var sw = new Stopwatch();

            sw.Start();
            res = func.Invoke();
            sw.Stop();

            return sw.Elapsed;
        }
    }
}
