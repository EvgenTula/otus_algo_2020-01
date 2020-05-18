using System;

namespace Task6Tree
{
    public abstract class Tree<T>
        where T : IComparable
    {
        internal BinaryTreeNode<T> root;
        public abstract void insert(T val);
        public abstract bool search(T val);
        public abstract void remove(T val);
    }
}
