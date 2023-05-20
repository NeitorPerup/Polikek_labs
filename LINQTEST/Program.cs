using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var list = Helper.RandomList(20, -500, 500);
            //list.Add(list.FirstOrDefault(x => x % 2 == 1));
            //PrintList(list);
            //list = list.Where(x => x % 2 != 0).Distinct().ToList();
            //PrintList(list);

            //var maxminlist = list.Where(x => x == list.Max() || x == list.Min());
            //PrintList(maxminlist);

            int n = 8;
            var list = Enumerable.Range(1, n).Select(x => (long)x).ToList();
            long result = list.Count == 0 ? 1 : 
                list.Aggregate((long a, long b) =>
                {
                    return a * b;
                });
            Console.WriteLine(result);

            Console.ReadLine();
        }

        public static void PrintList(IEnumerable<int> list)
        {
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
