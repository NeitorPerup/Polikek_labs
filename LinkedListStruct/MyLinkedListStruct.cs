using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListStruct
{
    internal unsafe struct MyLinkedListStruct
    {
        private int count;
        private MyLinkedListNode* head;
        private MyLinkedListNode* tail;
        
        public MyLinkedListStruct
        public void SortedInsert(MyLinkedListStruct* list, int value)
        {
            Node* node = (Node*)malloc(sizeof(Node));
            node->value = value;


            if (list->head == NULL)
            {
                list->head = node;
                list->tail = node;
                list->size = 1;
            }
            else
            {
                list->size += 1;
                Node* current = list->head;
                while (current != NULL)
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
                if (current == NULL)
                {
                    // вставляем в конец
                    current->prev = list->tail;
                    list->tail->next = current;
                    list->tail = current;
                }
                // если вставляем 2 элемент
                if (list->size = 2)
                {
                    list->head->next = list->tail;
                    list->tail->prev = list->head;
                }
            }
        } 

        public void PrintList()
        {
            MyLinkedListNode* current = head;
            while (current != null) 
            { 
                Console.Write(current->value + " ");
            }
        }
    }

    internal unsafe struct MyLinkedListNode
    {
        public int value;
        public MyLinkedListNode* next;
        public MyLinkedListNode* prev;

        public MyLinkedListNode(int value)
        {
            this.value = value;
            next = null; 
            prev = null;
        }
    }
}
