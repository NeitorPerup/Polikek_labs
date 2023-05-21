using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class HashTable
    {
        private LinkedList<string>[] items;
        private int size;

        public HashTable()
        {
            size = 101;
            items = new LinkedList<string>[size];
        }

        private int HashFunction(string item)
        {
            int hash = 0;
            foreach(var ch in item)
            {
                hash += Convert.ToInt32(ch);
            }

            hash %= size;

            return hash;
        }

        public void Add(string item)
        {
            var hash = HashFunction(item);
            if (items[hash] == null)
            {
                items[hash] = new LinkedList<string>();
                items[hash].AddLast(item);
            }
            else
            {
                items[hash].AddLast(item);
            }
        }

        public bool Contains(string item)
        {
            var hash = HashFunction(item);
            if (items[hash] == null)
                return false;

            foreach (var data in items[hash])
            {
                if (data.Equals(item))
                    return true;
            }

            return false;
        }

        public void Delete(string item)
        {
            var hash = HashFunction(item);
            if (items[hash] == null)
                return;

            foreach (var data in items[hash])
            {
                if (data.Equals(item))
                {
                    items[hash].Remove(item);
                    break;
                }
                    
            }

            return;
        }

        public string Get(string item)
        {
            var hash = HashFunction(item);
            if (items[hash] == null)
                return null;

            foreach (var data in items[hash])
            {
                if (data.Equals(item))
                    return data;
            }

            return null;
        }

        public void PrintTable()
        {
            for (int i = 0; i < size; i++)
            {
                if (items[i] != null && items[i].Count > 0) 
                {
                    foreach (var item in items[i])
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }
    }
}
