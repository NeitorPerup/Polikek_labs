using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hash = new HashTable();
            Console.WriteLine(hash.Contains("я") ? "have ya" : "doesnt have ya");
            hash.Add("я");
            Console.WriteLine(hash.Contains("я") ? "have ya" : "doesnt have ya");
            hash.Delete("я");
            Console.WriteLine(hash.Contains("я") ? "have ya" : "doesnt have ya");


            hash.Add("бы");
            hash.Add("хотел");
            hash.Add("чтобы");
            hash.Add("меня");
            hash.Add("называли");
            hash.Add("все");
            hash.Add("талант");

            hash.PrintTable();
            Console.ReadLine();
        }
    }
}
