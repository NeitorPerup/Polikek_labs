using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private LinkedList<T> Heap;

        public BinaryHeap()
        {
            Heap = new LinkedList<T>();
        }

        public void Insert(T item)
        {
            Heap.AddLast(item);
            var node = Heap.Last;
            while (node != null && node.Previous != null && node.Value.CompareTo(node.Previous.Value) < 0)
            {
                SwapNodes(node, node.Previous);
                node = node.Previous;
            }
        }

        public T Pop()
        {
            if (Heap.Count == 0)
                throw new InvalidOperationException("The heap is empty.");

            T result = Heap.First.Value;
            Heap.RemoveFirst();

            if (Heap.Count > 1)
            {
                Heap.AddFirst(Heap.Last.Value);
                Heap.RemoveLast();

                var node = Heap.First;
                while (node != null && (node.Next != null && node.Next.Next != null))
                {
                    var childNode = node.Next;
                    if (childNode.Next != null && childNode.Next.Value.CompareTo(childNode.Value) < 0)
                        childNode = childNode.Next;
                    if (childNode.Value.CompareTo(node.Value) < 0)
                        SwapNodes(node, childNode);
                    else
                        break;
                }
            }

            return result;
        }

        private void SwapNodes(LinkedListNode<T> node1, LinkedListNode<T> node2)
        {
            T temp = node1.Value;
            node1.Value = node2.Value;
            node2.Value = temp;
        }
    }
}
