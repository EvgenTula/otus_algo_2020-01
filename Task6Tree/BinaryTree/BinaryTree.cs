using System;

namespace Task6Tree
{
    public class BinaryTree<T> : Tree<T,BinaryTreeNode<T>>
        where T : IComparable
    {
        public override void insert(T val)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(val);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                BinaryTreeNode<T> parentNode = root;
                while (parentNode != null)
                {
                    int result = parentNode.value.CompareTo(newNode.value);
                    if (result >= 0)
                    {                        
                        if (parentNode.left == null)
                        {
                            parentNode.left = newNode;
                            break;
                        }
                        parentNode = parentNode.left;
                    }
                    if (result < 0)
                    {
                        if (parentNode.right == null)
                        {
                            parentNode.right = newNode;
                            break;
                        }
                        parentNode = parentNode.right;
                    }
                }
            }
        }

        public override void remove(T val)
        {
            BinaryTreeNode<T> parent;
            BinaryTreeNode<T> current = searchWithParent(val, out parent);
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
                    if (parent == null)
                    {
                        root = current.right;
                    }
                    else
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
                }
                else
                {
                    if (parent == null)
                    {
                        root = current.left;
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

                if (parent == null)
                {
                    root = binaryTreeNode;
                }
                else
                {
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
        }

        public override BinaryTreeNode<T> search(T val)
        {
            return searchWithParent(val, out _);
        }

        private BinaryTreeNode<T> searchWithParent(T val, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> result = root;
            parent = null;
            while (result != null)
            {
                int compare = result.value.CompareTo(val);
                if (compare > 0)
                {
                    parent = result;
                    result = result.left;
                }
                if (compare < 0)
                {
                    parent = result;
                    result = result.right;
                }
                if (compare == 0)
                {
                    return result;
                }
            }
            return null;
        }         
    }
}
