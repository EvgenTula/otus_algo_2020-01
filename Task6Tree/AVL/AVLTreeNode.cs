using System;

namespace Task6Tree
{
    public class AVLTreeNode<T> : TreeNode<T, AVLTreeNode<T>>
        where T : IComparable
    {
        public AVLTreeNode(T value)
        {
            this.value = value;
        }

        private int height = 1;
        public int Height()
        {
            return height;
        }

        public void HeightRecalc()
        {
            int leftH = left == null ? 0 : left.Height();
            int rightH = right == null ? 0 : right.Height();
            height = Math.Max(leftH, rightH) + 1;
        }

        public int BalabceFactor()
        {
            int leftH = left == null ? 0 : left.Height();
            int rightH = right == null ? 0 : right.Height();
            return leftH - rightH;
        }
    }
}
