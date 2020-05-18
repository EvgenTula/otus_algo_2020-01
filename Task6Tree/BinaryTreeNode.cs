using System;

namespace Task6Tree
{
    public class BinaryTreeNode<T> : IComparable
        where T: IComparable
    {        
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;
        public T value { private set; get; }

        public BinaryTreeNode(T value)
        {
            this.value = value;
        }

        private int CompareTo(BinaryTreeNode<T> obj)
        {
            return value.CompareTo(obj.value);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((BinaryTreeNode<T>)obj);           
        }
    }
}
