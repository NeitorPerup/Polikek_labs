using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roflan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MyLinkedList

            var list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddFirst(3);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddLast(12);
            list.AddFirst(6);
            list.AddLast(7);
            list.AddLast(33);
            list.AddFirst(9);

            Console.WriteLine(list.Contains(6) ? "6 есть в списке" : "6 нет в списке");
            list.Delete(6);
            Console.WriteLine(list.Contains(6) ? "6 есть в списке" : "6 нет в списке");

            // 9 6 5 3 1 8 12 7 33 

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();

            #endregion

            HashSet<int> set = new HashSet<int>();
        }
    }
}
