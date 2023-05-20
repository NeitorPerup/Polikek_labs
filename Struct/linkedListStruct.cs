using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Struct
{
    internal unsafe struct LinkedListStruct
    {
        public int count;
        public Node* head;
        public Node* tail;

        public void SortedInsert(LinkedListStruct* list, int value)
        {
            Node tmp = new Node(value);
            Node* node = &tmp;
            node->value = value;


            if (list->head == null)
            {
                list->head = node;
                list->tail = node;
                list->count = 1;
            }
            else
            {
                list->count += 1;
                Node* current = list->head;
                while (current != null)
                {
                    if (value < current->value)
                    {
                        // втсавляем node перед current
                        node->next = current->next;
                        node->prev = current;
                        current->next = node;
                        // если вставили вместо head
                        if (current->next == list->head)
                        {
                            list->head = current;
                        }
                        break;
                    }
                    current = current->next;
                }
                if (current == null)
                {
                    // вставляем в конец
                    current->prev = list->tail;
                    list->tail->next = current;
                    list->tail = current;
                }
                // если вставляем 2 элемент
                if (list->count == 2)
                {
                    list->head->next = list->tail;
                    list->tail->prev = list->head;
                }
            }
        }

        public void PrintList()
        {
            Node* current = head;
            while (current != null)
            {
                Console.Write(current->value + " ");
            }
        }
    }

    internal unsafe struct Node
    {
        public int value;
        public Node* next;
        public Node* prev;

        public Node(int value)
        {
            this.value = value;
            next = null;
            prev = null;
        }
    }
}
