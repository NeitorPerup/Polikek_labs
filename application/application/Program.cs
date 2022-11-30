using System;
using System.Linq;
using System.Diagnostics;
using Apache.Ignite;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Client;
using Apache.Ignite.Core.Deployment;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Discovery.Tcp.Static;
using Apache.Ignite.Core.Events;
using Apache.Ignite.Core.Log;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var matrixLen = 1000;
                var Matrix = new int[matrixLen, matrixLen];

                Random rand = new Random();
                for (int i = 0; i < matrixLen; ++i)
                {
                    for (int j = 0; j < matrixLen; ++j)
                    {
                        Matrix[i, j] = rand.Next(int.MaxValue);
                    }
                }

                var cfg = new IgniteConfiguration
                {
                   // PluginConfigurations = new[] { "127.0.0.1:47500..47505" },
                    DiscoverySpi = new TcpDiscoverySpi
                    {
                        IpFinder = new TcpDiscoveryStaticIpFinder
                        {
                            Endpoints = new[] { "127.0.0.1:47500..47509" }
                        },
                        SocketTimeout = TimeSpan.FromSeconds(0.3),
                        ForceServerMode = false
                    },
                    IncludedEventTypes = EventType.CacheAll,
                    JvmOptions = new[] { "-Xms1024m", "-Xmx1024m" }
                };

                using (var client = Ignition.Start(cfg))
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    var compute = client.GetCluster().ForServers().GetCompute();
                    int portCount = 10;

                    var calls = new RemoteTask[portCount];
                    for (int i = 0; i < portCount; ++i)
                    {
                        int start = i * matrixLen / portCount;
                        int end = (i + 1) * matrixLen / portCount;
                        calls[i] = new RemoteTask(Matrix, start, end, matrixLen);
                    }

                    var res = compute.Call(calls);
                    var maximum = res.Max();

                    sw.Stop();
                    Console.WriteLine($"\n\nРезультат = {maximum}, время = {sw.Elapsed.TotalMilliseconds} ms\n\n");
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n{ex?.InnerException}");
            }
        }
    }
}
