using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(MyService.Service)))
            {
                host.Open();
                Console.WriteLine("Хост запущен");
                Console.ReadLine();
            }
        }
    }
}
