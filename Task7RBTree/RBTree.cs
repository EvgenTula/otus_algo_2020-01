using System;
using System.ComponentModel;

namespace Task7RBTree
{
    class RBTree<T> : Tree<T, RBTreeNode<T>>
        where T : IComparable
    {
        public override RBTreeNode<T> root { 
            get => base.root;
            set
            { 
                base.root = value;
                base.root.parent = null;
                base.root.color = Color.Black;
            }
        }

        private RBTreeNode<T> grandparent(RBTreeNode<T> node)
        {
            if (node.parent !=null)
            {
                return node.parent.parent;
            }
            return null;
        }

        private RBTreeNode<T> uncle(RBTreeNode<T> node)
        {
            RBTreeNode<T> gnode = grandparent(node);
            if (gnode == null)
                return null;
            if (node.parent == gnode.left)
                return gnode.right;
            else
                return gnode.left;
        }

        private RBTreeNode<T> sibling(RBTreeNode<T> node)
        {
            if (node.parent.left == node)
                return node.parent.right;
            else
                return node.parent.left;
        }

    public override void insert(T val)
        {
            RBTreeNode<T> newNode = new RBTreeNode<T>(val, null);
            if (root == null)
            {                
                root = newNode;
            }
            else
            {
                RBTreeNode<T> currentNode = root;

                while (currentNode != null)
                {
                    int result = currentNode.value.CompareTo(newNode.value);
                    if (result >= 0)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            break;
                        }                     
                        currentNode = currentNode.left;
                    }

                    if (result < 0)
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            break;
                        }
                        currentNode = currentNode.right;
                    }

                    
                    if (currentNode.parent.color == Color.Red && currentNode.color == Color.Red)
                    {
                        var grandNode = currentNode.parent.parent;
                        var parentNode = currentNode.parent;
                        if ((grandNode.left == parentNode && parentNode.left == newNode) ||
                            (grandNode.right == parentNode && parentNode.right == newNode))
                        {
                            grandNode.invert();
                            parentNode.invert();
                            RBTreeNode<T> parent = grandNode.parent;
                            if (parent.left == grandNode)
                                parent.left = smallRightRotation(grandNode);
                            else
                                parent.right = smallLeftRotation(grandNode);
                        }

                        if ((grandNode.left == parentNode && parentNode.right == newNode) ||
                            (grandNode.right == parentNode && parentNode.left == newNode))
                        {
                            flip(grandNode);
                            flip(newNode);
                            if (grandNode.left == parentNode)
                                grandNode.left = smallLeftRotation(parentNode);
                            else
                                grandNode.right = smallRightRotation(parentNode);
                            RBTreeNode<T> parent = grandNode.parent;
                            if (parent.left == grandNode)
                                parent.left = smallRightRotation(grandNode);
                            else
                                parent.right = smallLeftRotation(grandNode);
                        }
                    }                    
                }
                check(newNode);              
            }
        }

        private void check(RBTreeNode<T> node)
        {
            //1
            if (node.parent == null)
            {
                node.color = Color.Black;
            }
            else
            {
                //2
                if (node.parent.color == Color.Black)
                {
                    return;
                }
                else
                {
                    //3
                    RBTreeNode<T> parentNode = node.parent;
                    RBTreeNode<T> grandparentNode = grandparent(node);
                    RBTreeNode<T> uncleNode = uncle(node);

                    if (uncleNode != null && uncleNode.color == Color.Red)
                    {
                        parentNode.color = Color.Black;
                        uncleNode.color = Color.Black;
                        grandparentNode.color = Color.Red;
                        check(grandparentNode);
                    }
                    else
                    {
                        //4
                        if (node.parent.right == node && grandparentNode.left == node.parent)
                        {
                            grandparentNode.left = smallLeftRotation(node.parent);
                            node = node.left;
                        }
                        else if (node.parent.left == node && grandparentNode.right == node.parent)
                        {
                            grandparentNode.right = smallRightRotation(node.parent);
                            node = node.right;
                        }
                        grandparentNode = grandparent(node);
                        //5
                        node.parent.color = Color.Black;
                        grandparentNode.color = Color.Red;
                        if (node.parent.left == node && grandparentNode.left == node.parent)
                        {
                            if (grandparentNode == root)
                            {
                                root = smallRightRotation(grandparentNode);
                            }
                            else
                            {
                                if (grandparentNode.parent.left == grandparentNode)
                                    grandparentNode.parent.left = smallRightRotation(grandparentNode);
                                else
                                    grandparentNode.parent.right = smallRightRotation(grandparentNode);
                            }
                        }
                        else
                        {
                            if (grandparentNode == root)
                            {
                                root = smallLeftRotation(grandparentNode);
                            }
                            else
                            {
                                if (grandparentNode.parent.left == grandparentNode)
                                    grandparentNode.parent.left = smallLeftRotation(grandparentNode);
                                else
                                    grandparentNode.parent.right = smallLeftRotation(grandparentNode);
                            }
                        }                      
                    }
                }
            }
        }
        //TODO: доделать!!!
        public override void remove(T val)
        {
            
            RBTreeNode<T> node = search(val);

            if (node == null)
            {
                return;
            }
            RBTreeNode<T> parentNode = node.parent;
           
            //Удаление листа
            if (node.left == null && node.right == null)
            {
                if (parentNode.left == node)
                {
                    parentNode.left = null;
                }
                else
                {
                    parentNode.right = null;
                }
                return;
            }

            //Удаляемый элемент имеет одного потомка
            if (node.left == null || node.right == null)
            {
                if (node.left == null)
                {
                    if (parentNode == null)
                    {
                        root = node.right;
                    }
                    else
                    {
                        if (parentNode.left == node)
                        {
                            parentNode.left = node.right;
                            //balance
                            //parent.left.color = current.color;
                        }
                        else
                        {
                            parentNode.right = node.right;
                            //balance
                            //parent.right.color = current.color;
                        }
                    }
                }
                else
                {
                    if (parentNode == null)
                    {
                        root = node.left;
                    }
                    else
                    {
                        if (parentNode.left == node)
                        {
                            parentNode.left = node.left;
                            //balance
                            //parent.left.color = current.color;
                        }
                        else
                        {
                            parentNode.right = node.left;
                            //balance
                            //parent.right.color = current.color;
                        }
                    }
                }
                //return;
            } 
            else
            //Удаляемый элемент имеет двух потомков
            //if (current.left != null && current.right != null)
            {
                RBTreeNode<T> binaryTreeNode = node.left;
                RBTreeNode<T> parentBinaryTreeNode = node;
                while (binaryTreeNode.right != null)
                {
                    parentBinaryTreeNode = binaryTreeNode;
                    binaryTreeNode = binaryTreeNode.right;
                }

                binaryTreeNode.right = node.right;

                if (parentBinaryTreeNode != node)
                {
                    parentBinaryTreeNode.right = binaryTreeNode.left;
                    binaryTreeNode.left = node.left == binaryTreeNode ? null : node.left;
                }

                if (parentNode == null)
                {
                    root = binaryTreeNode;
                }
                else
                {
                    if (parentNode.left == node)
                    {
                        parentNode.left = binaryTreeNode;
                    }
                    else
                    {
                        parentNode.right = binaryTreeNode;
                    }
                }
            }

            if (node.color == Color.Black)
            {
                //fixBalance(current);
            }
            
        }

        public override RBTreeNode<T> search(T val)
        {
            RBTreeNode<T> result = root;
            while (result != null)
            {
                int compare = result.value.CompareTo(val);
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
                    return result;
                }
            }
            return null;
        }

        private void flip(RBTreeNode<T> node)
        {
            if (node != root)
            {
                node.color = Color.Red;
            }
            if (node.left != null)
                node.left.color = Color.Black;
            if (node.right != null)
                node.right.color = Color.Black;
        }

        private RBTreeNode<T> smallLeftRotation(RBTreeNode<T> node)
        {
            RBTreeNode<T> right = node.right;
            node.right = right.left;
            right.left = node;
            return right;
        }

        private RBTreeNode<T> smallRightRotation(RBTreeNode<T> node)
        {
            RBTreeNode<T> left = node.left;
            node.left = left.right;
            left.right = node;
            return left;
        }
    }
}
