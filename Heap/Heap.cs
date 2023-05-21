using System;

namespace Heap
{
    public class Heap
    {
        private Node _head;
        public int Size;

        public Node Head { get { return _head; } }

        public Heap(int value)
        {
            Size = 1;
            _head = new Node(value, Size);
        }

        public void Add(int value)
        {
            Size++;
            var node = new Node(value, Size);
            var current = _head;
            
            var route = GetRoute(Size);
            for (int i = 0; i < route.Length; i++)
            {
                // left
                if (route[i] == 2 * current.Index)
                    current = current.Left;
                if (route[i] == 2 * current.Index + 1)
                    current = current.Right;
            }

            if (Size == 2 * current.Index)
                current.Left = node;
            if (Size == 2 * current.Index + 1)
                current.Right = node;

            node.Parent = current;

            // ставим тварь на место
            current = node;
            while (current != null && current.Parent != null && current.Value > current.Parent.Value)
            {
                Swap(current.Parent, current);
                current = current.Parent;
            }

            if (current.Parent == null)
            {
                _head = current;
            }
        }

        public void PrintHeap(Node node)
        {
            var current = node;
            if (current == null)
                return;

            Console.Write(current.Value + " ");
            PrintHeap(current.Left);
            PrintHeap(current.Right);
        }

        private void Swap(Node node1, Node node2)
        {
            int tmp = node1.Value;
            node1.Value = node2.Value;
            node2.Value = tmp;
        }

        private int[] GetRoute(int index)
        {
            var n = (int)Math.Ceiling(Math.Log(index, 2)); // берем логарифм, округляем вверх
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                index /= 2;
                result[n - i - 1] = index; // вставляем справа налево
            }

            return result;
        }
    }

    public class Node
    {
        public int Value;
        public int Index;
        public Node Left;
        public Node Right;
        public Node Parent;

        public Node(int value, int index)
        {
            Value = value;
            Index = index;
            Left = null;
            Right = null;
            Parent = null;
        }
    }
}
