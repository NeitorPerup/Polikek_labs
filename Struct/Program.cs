using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal class Program
    {
        static unsafe void Main(string[] args)
        {
            var list = createList();
            list->SortedInsert(list, 5);
            list->SortedInsert(list, 6);
            list->SortedInsert(list, 2);
            list->SortedInsert(list, 1);
            list->SortedInsert(list, 4);
            list->SortedInsert(list, 8);

            list->PrintList();
        }

        static unsafe LinkedListStruct* createList()
        {
            var tmp = new LinkedListStruct();
            var list = &tmp;
            list->count = 0;
            list->tail = null;
            list->head = null;

            return list;
        }
    }
}
