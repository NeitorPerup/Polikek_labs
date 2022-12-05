using Apache.Ignite.Core;
using Apache.Ignite.Core.Compute;
using Apache.Ignite.Core.Services;
using System;
using System.Diagnostics;
using System.Linq;

namespace application
{
    public class RemoteTaskService : IService
    {
        private int[,] Matrix;
        private int MatrixLen;
        private double TimeMs;

        public RemoteTaskService()
        {
        }

        public void Cancel(IServiceContext context)
        {
            Console.WriteLine("Service initialized: " + context.Name);
        }

        public void Execute(IServiceContext context)
        {
            Console.WriteLine("Service started: " + context.Name);
        }

        public void Init(IServiceContext context)
        {
            Console.WriteLine("Service cancelled: " + context.Name);
        }

        public void CreateMatrix(int matrixLen)
        {
            MatrixLen = matrixLen;
            Matrix = new int[matrixLen, matrixLen];

            Random rand = new Random();
            for (int i = 0; i < matrixLen; ++i)
            {
                for (int j = 0; j < matrixLen; ++j)
                {
                    Matrix[i, j] = rand.Next(int.MaxValue);
                }
            }
        }

        public int Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var compute = Program.Ignite.GetCluster().ForServers().GetCompute();
            int portCount = 10;

            var calls = new RemoteTask[portCount];
            for (int i = 0; i < portCount; ++i)
            {
                int start = i * MatrixLen / portCount;
                int end = (i + 1) * MatrixLen / portCount;
                calls[i] = new RemoteTask(Matrix, start, end, MatrixLen);
            }

            var resList = compute.Call(calls);
            var result = resList.Max();

            sw.Stop();
            TimeMs =  sw.Elapsed.TotalMilliseconds;

            return result;
        }

        public double GetTime()
        {
            return TimeMs;
        }
    }
}
