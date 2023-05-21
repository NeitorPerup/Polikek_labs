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
            //var list = createList();
            //list->SortedInsert(list, 5);
            //list->SortedInsert(list, 6);
            //list->SortedInsert(list, 2);
            //list->SortedInsert(list, 1);
            //list->SortedInsert(list, 4);
            //list->SortedInsert(list, 8);

            //list->PrintList();

            //var tree = Create(8);
            BinaryTree obj = new BinaryTree();
            BinaryTree* tree = &obj;
            BinaryNode headObj = new BinaryNode();
            BinaryNode* head = &headObj;
            head->Left = null;
            head->Right = null;
            head->Value = 8;

            tree->Head = head;


            tree->Insert(tree, 5);
            tree->Insert(tree, 12);
            tree->Insert(tree, 9);
            tree->Insert(tree, 1);
            tree->Insert(tree, 6);
            tree->Insert(tree, 15);

            tree->PrinTree(tree, tree->Head);

            Console.ReadLine();
        }

        public static unsafe BinaryTree* Create(int value)
        {
            BinaryTree obj = new BinaryTree();
            BinaryTree* tree = &obj;
            BinaryNode headObj = new BinaryNode();
            BinaryNode* head = &headObj;
            head->Left = null;
            head->Right = null;
            head->Value = value;

            tree->Head = head;
            return tree;
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
