using Apache.Ignite.Core;
using Apache.Ignite.Core.Client;
using Apache.Ignite.Core.Client.Cache;
using System;

namespace Client
{
    class Program
    {
        private const string ServiceName = "default-map-service";
        private const string CacheName = "cache";

        static void Main(string[] args)
        {
            try
            {
                var cfg = new IgniteClientConfiguration
                {
                    Endpoints = new[]
                {
                    "127.0.0.1"
                }
                };

                using (var ignite = Ignition.StartClient(cfg))
                {
                    Console.WriteLine();
                    Console.WriteLine(">>> Client started.");

                    int matrixLen = 500;
                    
                    var prx = ignite.GetServices().GetServiceProxy<IRemoteTaskService>(ServiceName);
                    prx.CreateMatrix(matrixLen);
                    int result = prx.Start();
                    double timeMs = prx.GetTime();
                    Console.WriteLine($"\n\nРезультат = {result}, время = {timeMs} ms\n\n");

                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($">>> {ex.Message}\n>>>{ex?.InnerException}");
            }
            finally
            {
                Console.WriteLine("\n>>> Example finished, press any key to exit ...");
                Console.ReadKey();
            }
        }
    }

    public interface IRemoteTaskService
    {
        void CreateMatrix(int matrixLen);

        int Start();

        double GetTime();
    }
}
