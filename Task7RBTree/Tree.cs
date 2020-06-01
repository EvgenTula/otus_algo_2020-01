using System;

namespace Task7RBTree
{
    public abstract class Tree<T, F>
        where T : IComparable
        where F : TreeNode<T,F>
    {
        public virtual F root { get; set; }
        public abstract void insert(T val);
        public abstract F search(T val);
        public abstract void remove(T val);
    }
}
