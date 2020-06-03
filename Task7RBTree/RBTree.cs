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
                base.root.parent = null;
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
                //check(newNode);
                
                //1
                if (newNode.parent == null)
                {
                    return;
                }
                //2
                if (newNode.parent.color == Color.Black)
                {
                    return;
                }
                //3
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
                    RBTreeNode<T> parent = node.parent;
                    RBTreeNode<T> grandParent = parent.parent;
                    RBTreeNode<T> uncle = grandParent.left == parent ? grandParent.right : grandParent.left;

                    if (uncle != null && uncle.color == Color.Black)
                    {
                        parent.color = Color.Black;
                        uncle.color = Color.Black;
                        grandParent.color = Color.Red;

                        check(grandParent);
                    }
                    else
                    {
                        if (node.parent.right == node && node.parent.parent.left == node.parent)
                        {
                            node.parent.parent.left = smallLeftRotation(node.parent);
                        }
                        else
                        {
                            if (node.parent.left == node && node.parent.parent.right == node.parent)
                            {
                                node.parent.parent.right = smallRightRotation(node.parent);
                                node.parent.color = Color.Black;
                                node.parent.parent.color = Color.Red;
                                if (node.parent.left == node && node.parent.parent.left == node.parent)
                                {
                                    if (node.parent.parent.parent.left == node.parent.parent)
                                        node.parent.parent.parent.left = smallRightRotation(node.parent.parent);
                                    else
                                        node.parent.parent.parent.right = smallRightRotation(node.parent.parent);
                                }
                                else
                                {
                                    if (node.parent.parent.parent.left == node.parent.parent)
                                        node.parent.parent.parent.left = smallLeftRotation(node.parent.parent);
                                    else
                                        node.parent.parent.parent.right = smallLeftRotation(node.parent.parent);

                                }
                            }
                        }

                    }
                }
            }
        }
        public override void remove(T val)
        {
            
            RBTreeNode<T> current = searchWithParent(val);

            if (current == null)
            {
                return;
            }
            RBTreeNode<T> parent = current.parent;
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
                            //balance
                            //parent.left.color = current.color;
                        }
                        else
                        {
                            parent.right = current.right;
                            //balance
                            //parent.right.color = current.color;
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
                            //balance
                            //parent.left.color = current.color;
                        }
                        else
                        {
                            parent.right = current.left;
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

            if (current.color == Color.Black)
            {
                //fixBalance(current);
            }
        }

        private void fixBalance(RBTreeNode<T> node)
        {
            //TODO ...
            if (node.parent.left == node)
            {
                if (node.parent.right.color == Color.Red)
                {

                }
            }
            else
            {

            }

        }

        public override RBTreeNode<T> search(T val)
        {
            return searchWithParent(val);
        }

        private RBTreeNode<T> searchWithParent(T val)
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
