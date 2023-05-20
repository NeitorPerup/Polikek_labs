using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roflan
{
    internal class MyLinkedListNode<T>
    {
        internal T item;
        internal MyLinkedListNode<T> next;
        internal MyLinkedListNode<T> previous;

        public MyLinkedListNode(T item)
        {
            this.item = item;
        }

        public MyLinkedListNode<T> Next { get { return this.next; } }
        public MyLinkedListNode<T> Previous { get { return this.previous; } }
    }
}
