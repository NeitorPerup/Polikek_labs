using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Deployment;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Discovery.Tcp.Static;
using Apache.Ignite.Core.Events;
using Apache.Ignite.Core.Log;

namespace application
{
    class Program
    {
        public static IIgnite Ignite;
        static void Main(string[] args)
        {
            try
            {
                var cfg = new IgniteConfiguration
                {
                    Localhost = "127.0.0.1",
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
                    JvmOptions = new[] { "-Xms1024m", "-Xmx1024m" },
                    Logger = new ConsoleLogger
                    {
                        MinLevel = LogLevel.Error
                    },
                    PeerAssemblyLoadingMode = PeerAssemblyLoadingMode.CurrentAppDomain
                };

                using (var ignite = Ignition.Start(cfg))
                {
                    Ignite = ignite;
                    //var compute = ignite.GetCluster().ForServers().GetCompute();
                    ignite.GetServices().DeployNodeSingleton("default-map-service", new RemoteTaskService());

                    Console.WriteLine();
                    Console.WriteLine(">>> Server node started, press any key to exit ...");

                    Console.ReadKey();
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n{ex?.InnerException}");
            }
        }
    }
}
