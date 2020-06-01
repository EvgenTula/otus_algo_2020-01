using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Task7RBTree
{
    public enum Color
    { 
        Red = 1,
        Black = 2
    }

    public class RBTreeNode<T> : TreeNode<T, RBTreeNode<T>>
        where T: IComparable
    {
        public RBTreeNode<T> parent;

        public override RBTreeNode<T> left
        {
            get => base.left;
            set
            {
                base.left = value;
                if (base.left != null)
                    base.left.parent = this;
            }
        }

        public override RBTreeNode<T> right
        {
            get => base.right;
            set
            {
                base.right = value;
                if (base.right != null)
                    base.right.parent = this;
            }
        }


        public RBTreeNode(T value, RBTreeNode<T> parent )
        {
            this.value = value;
            this.color = Color.Red;
            this.parent = parent;
        }
        public Color color { get; set; }

        public void invert()
        {
            if (color == Color.Black)
                color = Color.Red;
            else
                color = Color.Black;
        }
    }
}
