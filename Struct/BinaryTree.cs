using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal unsafe struct BinaryTree
    {
        public BinaryNode* Head;

        

        public void Insert(BinaryTree* tree, int value)
        {
            //BinaryNode* node = (BinaryNode*)tree;
            var nodeTmp = new BinaryNode();
            BinaryNode* node = &nodeTmp;
            node->Value = value;
            node->Left = null;
            node->Right = null;

            var current = tree->Head;
            while (current != null)
            {
                if (value < current->Value)
                {
                    if (current->Left == null)
                    {
                        current->Left = node;
                        break;
                    }
                    current = current->Left;

                }
                else
                {
                    if (current->Right == null)
                    {
                        current->Right = node;
                        break;
                    }
                    current = current->Right;
                }    
            }
        }

        public void PrinTree(BinaryTree* tree, BinaryNode* node)
        {
            var current = node;
            if (current == null)
                return;

            tree->PrinTree(tree, current->Left);
            //tree->PrinTree(tree, current);
            Console.Write(current->Value + " ");
            tree->PrinTree(tree, current->Right);
        }
    }

    public unsafe struct BinaryNode
    {
        public int Value;
        public BinaryNode* Left;
        public BinaryNode* Right;
    }
}
