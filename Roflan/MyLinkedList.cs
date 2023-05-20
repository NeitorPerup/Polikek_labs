using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roflan
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        internal MyLinkedListNode<T> _head;
        internal MyLinkedListNode<T> _tail;
        private int count = 0;
        public MyLinkedList() { }

        public int Count { get { return count; } }

        public void AddLast(T item)
        {
            var node = new MyLinkedListNode<T>(item);
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                node.previous = _tail;
                _tail.next = node;
                if (_tail.previous == null)
                    _tail.previous = _head;
                _tail = node;
            }
            count++;
        }

        public void AddFirst(T item)
        {
            var node = new MyLinkedListNode<T>(item);
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _head.previous = node;
                if (_head.next == null)
                    _head.next = _tail;
                node.next = _head;
                _head = node;
                count++;
            }
        }

        public void Delete(T item)
        {
            var next = _head;

            while (true)
            {
                if (next == null)
                    break;

                if (next.item.Equals(item))
                {
                    var prev = next.previous;
                    var newNext = next.next;

                    prev.next = newNext;
                    next.previous = prev;
                    break;
                }

                next = next.next;
            }
        }

        public bool Contains(T item)
        {
            var next = _head;
            
            while (true)
            {
                if (next == null)
                    return false;

                if (next.item.Equals(item))
                    return true;
                next = next.next;
            }
        }

        public void Clear()
        {

        }

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private MyLinkedList<T> list;
            private MyLinkedListNode<T> node;
            private int index;
            private T current;

            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current 
            { 
                get
                {
                    if (index == 0 || index == list.Count + 1)
                        throw new IndexOutOfRangeException();
                    return current;
                }
            }

            internal Enumerator(MyLinkedList<T> list)
            {
                this.list = list;
                node = list._head;
                current = default(T);
                index = 0;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (node == null)
                {
                    index = list.Count + 1;
                    return false;
                }

                current = node.item;
                node = node.Next;
                
                index++;

                return true;
            }

            public void Reset()
            {
                node = list._head;
                current = default(T);
                index = 0;
            }


        }
        #endregion
    }
}
