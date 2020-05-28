using System;

namespace Task6Tree
{
    public class BinaryTreeNode<T> : TreeNode<T,BinaryTreeNode<T>>
        where T: IComparable
    {        
        public BinaryTreeNode(T value)
        {
            this.value = value;
        }
    }
}
