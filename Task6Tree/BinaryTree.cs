using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task6Tree
{
    public class BinaryTree<T> : Tree<T>
        where T : IComparable
    {
        
        public override void insert(T val)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(val);
            }
            else
            {
                BinaryTreeNode<T> current;
                searchWithParent(val, out current);
                int result = current.value.CompareTo(val);
                if (result > 0)
                {
                    current.left = new BinaryTreeNode<T>(val);
                }
                if (result < 0)
                {
                    current.right = new BinaryTreeNode<T>(val);
                }
            }
        }

        public override void remove(T val)
        {
            BinaryTreeNode<T> current = null;
            BinaryTreeNode<T> parent = null;
            current = searchWithParent(val, out parent);
            if (current == null)
            {
                return;
            }

            //Удаление листа
            if (current.left == null && current.right == null)
            {
                if (parent.left == current)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
                return;
            }

            //Удаляемый элемент имеет одного потомка
            if (current.left == null || current.right == null)
            {
                if (current.left == null)
                {
                    if (parent.left == current)
                    {
                        parent.left = current.right;
                    }
                    else
                    {
                        parent.right = current.right;
                    }
                }
                else
                {
                    if (parent.left == current)
                    {
                        parent.left = current.left;
                    }
                    else
                    {
                        parent.right = current.left;
                    }
                }               
                return;
            }

            //Удаляемый элемент имеет двух потомков
            if (current.left != null && current.right != null)
            {            
                BinaryTreeNode<T> binaryTreeNode = current.left;
                BinaryTreeNode<T> parentBinaryTreeNode = current;
                while (binaryTreeNode.right != null)
                {
                    parentBinaryTreeNode = binaryTreeNode;
                    binaryTreeNode = binaryTreeNode.right;
                }

                binaryTreeNode.right = current.right;

                if (parentBinaryTreeNode != current)
                {
                    parentBinaryTreeNode.right = binaryTreeNode.left;
                    binaryTreeNode.left = current.left == binaryTreeNode ? null : current.left;               
                }


                if (parent.left == current)
                {
                    parent.left = binaryTreeNode;
                }
                else
                {
                    parent.right = binaryTreeNode;
                }
            }            
        }

        public override bool search(T val)
        {
            BinaryTreeNode<T> parent;
            return searchWithParent(val, out parent) != null;
        }

        private BinaryTreeNode<T> searchWithParent(T val, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = root;
            parent = null;
            while (current != null)
            {
                int result = current.value.CompareTo(val);
                if (result > 0)
                {
                    parent = current;
                    current = current.left;
                }
                if (result < 0)
                {
                    parent = current;
                    current = current.right;
                }
                if (result == 0)
                {
                    return current;
                }
            }
            return null;
        }      
    }
}
