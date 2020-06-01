using System;

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
                base.root.color = Color.Black;
            }
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
                    if (currentNode.color == Color.Black)
                    {
                        if (currentNode.left?.color == Color.Red &&
                            currentNode.right?.color == Color.Red)
                        {
                            flip(currentNode);
                        }
                    }

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
                //1
                if (newNode.parent.color == Color.Black)
                {
                    return;
                }

                if (newNode.parent.color == Color.Red)
                {
                    var parentNode = newNode.parent;
                    //2
                    if ((parentNode.parent.left == currentNode && currentNode.left == newNode) ||
                        (parentNode.parent.right == currentNode && currentNode.right == newNode))
                    {
                        parentNode.parent.invert();
                        currentNode.invert();
                        RBTreeNode<T> grandParent = parentNode.parent;
                        if (grandParent.parent == null)
                        {
                            if (grandParent.left == currentNode)
                            {
                                root = smallRightRotation(grandParent);
                            }
                            else
                            {
                                root = smallLeftRotation(grandParent);
                            }
                        }
                        else
                        {
                            if (grandParent.parent.left == grandParent)
                                grandParent.parent.left = smallRightRotation(grandParent);
                            else
                                grandParent.parent.right = smallLeftRotation(grandParent);
                        }
                    }

                    //3
                    if ((parentNode.parent.left == currentNode && currentNode.right == newNode) ||
                        (parentNode.parent.right == currentNode && currentNode.left == newNode))
                    {
                        parentNode.parent.invert();
                        newNode.invert();

                        if (parentNode.parent.left == parentNode)
                            parentNode.parent.left = smallLeftRotation(parentNode);
                        else
                            parentNode.parent.right = smallRightRotation(parentNode);

                        RBTreeNode<T> grandParent = parentNode.parent;
                        if (grandParent.parent.parent == null)
                        {
                            if (parentNode.parent.left == currentNode)
                            {
                                root = smallRightRotation(grandParent.parent);
                            }
                            else
                            {
                                root = smallLeftRotation(grandParent.parent);
                            }
                        }
                        else
                        {
                            if (grandParent.parent.parent.left == grandParent.parent)
                                grandParent.parent.parent.left = smallRightRotation(grandParent.parent);
                            else
                                grandParent.parent.parent.right = smallLeftRotation(grandParent.parent);
                        }
                    }
                }
            }
        }

        public override void remove(T val)
        {
            RBTreeNode<T> parent;
            RBTreeNode<T> current = searchWithParent(val, out parent);
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
                RBTreeNode<T> binaryTreeNode = current.left;
                RBTreeNode<T> parentBinaryTreeNode = current;
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

        public override RBTreeNode<T> search(T val)
        {
            return searchWithParent(val, out _);
        }

        private RBTreeNode<T> searchWithParent(T val, out RBTreeNode<T> parent)
        {
            RBTreeNode<T> result = root;
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
