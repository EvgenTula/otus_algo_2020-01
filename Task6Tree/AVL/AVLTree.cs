using System;
using System.Collections.Generic;

namespace Task6Tree
{
    class AVLTree<T> : Tree<T,AVLTreeNode<T>>
        where T : IComparable
    {
        public override void insert(T val)
        {
            AVLTreeNode<T> newNode = new AVLTreeNode<T>(val);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                AVLTreeNode<T> parentNode = root;                
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
                rebalance(parentNode);
            }
        }

        public override void remove(T val)
        {    
            AVLTreeNode<T> parent;
            AVLTreeNode<T> current = searchWithParent(val, out parent);           

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
                rebalance(parent);
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
                rebalance(parent);
                return;
            }

            //Удаляемый элемент имеет двух потомков
            if (current.left != null && current.right != null)
            {
                AVLTreeNode<T> binaryTreeNode = current.left;
                AVLTreeNode<T> parentBinaryTreeNode = current;
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
                rebalance(binaryTreeNode);
            }
        }

        private void rebalance(AVLTreeNode<T> node)
        {
            Stack<AVLTreeNode<T>> nodeRebalance = new Stack<AVLTreeNode<T>>();
            AVLTreeNode<T> result = root;
            while (result != null)
            {
                nodeRebalance.Push(result);
                int compare = result.value.CompareTo(node.value);
                if (compare > 0)
                {
                    result = result.left;
                }
                if (compare < 0)
                {
                    result = result.right;
                }
                if (compare == 0)
                {
                    break;
                }
            }
            
            while (nodeRebalance.Count > 0)
            {
                var item = nodeRebalance.Pop();
                item.HeightRecalc();
                AVLTreeNode<T> parentNode;
                searchWithParent(item.value, out parentNode);
                if (parentNode == null)
                {
                    root = rotation(item);
                }
                else
                {
                    if (parentNode.left == item)
                        parentNode.left = rotation(item);
                    else
                        parentNode.right = rotation(item);

                    parentNode.HeightRecalc();
                }
            }
        }

        private AVLTreeNode<T> rotation(AVLTreeNode<T> node)
        {
            if (node.BalabceFactor() == 2)
            {
                return bigRightRotation(node);
            }
            if (node.BalabceFactor() == -2)
            {
                return bigLeftRotation(node);
            }
            return node;
        }

        public override AVLTreeNode<T> search(T val)
        {
            return searchWithParent(val, out _);            
        }

        private AVLTreeNode<T> searchWithParent(T val, out AVLTreeNode<T> parent)
        {
            AVLTreeNode<T> result = root;
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

        private AVLTreeNode<T> smallLeftRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> right = node.right;
            node.right = right.left;
            right.left = node;
            
            node.HeightRecalc();
            right.HeightRecalc();

            return right;
        }
        
        private AVLTreeNode<T> smallRightRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> left = node.left;
            node.left = left.right;
            left.right = node;

            node.HeightRecalc();
            left.HeightRecalc();

            return left;
        }

        private AVLTreeNode<T> bigLeftRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> right = node.right;
            if (right.BalabceFactor() > 0)
                node.right = smallRightRotation(right);
            node = smallLeftRotation(node);
            return node;
        }

        private AVLTreeNode<T> bigRightRotation(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> left = node.left;
            if (left.BalabceFactor() < 0)
                node.left = smallLeftRotation(left);
            node = smallRightRotation(node);
            return node;
        }


    }
}
