using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap(12);
            heap.Add(22);
            heap.Add(5);
            heap.Add(8);
            heap.Add(17);
            heap.Add(3);
            heap.Add(9);
            heap.Add(7);

            heap.PrintHeap(heap.Head);
            Console.ReadLine();
        }
    }
}
