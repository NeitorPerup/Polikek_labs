using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Text;

namespace application
{
    public class RemoteTask : IComputeFunc<int>
    {
        private int[,] Matrix;
        private int Start, EndI, EndJ;

        public RemoteTask(int[,] matrix, int start, int endI, int endJ)
        {
            Matrix = matrix;
            Start = start;
            EndJ = endJ;
            EndI = endI;
        }

        public int Invoke()
        {
            int max = int.MinValue;

            for (int i = Start; i < EndI; ++i)
            {
                for (int j = i + 1; j < EndJ; ++j)
                {
                    if (Matrix[i, j] > max)
                        max = Matrix[i, j];
                }
            }
            return max;
        }
    }
}
