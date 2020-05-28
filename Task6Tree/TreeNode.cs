using System;

namespace Task6Tree
{
    public abstract class TreeNode<T,F>
        where T : IComparable
        where F: TreeNode<T,F>
    {
        public F left { get; set; }
        public F right { get; set; }      
        public T value { protected set; get; }
    }
}
