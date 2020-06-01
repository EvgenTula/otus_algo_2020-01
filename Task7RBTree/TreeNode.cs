using System;

namespace Task7RBTree
{
    public abstract class TreeNode<T,F>
        where T : IComparable
        where F: TreeNode<T,F>
    {
        public virtual F left { get; set; }
        public virtual F right { get; set; }      
        public T value { protected set; get; }
    }
}
