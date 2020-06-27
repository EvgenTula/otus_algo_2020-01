using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task12MST
{
    public class Edge : IComparable
    {
        public int v1;
        public int v2;
        public int len;
        public Edge(int v1, int v2, int len)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.len = len;
        }

        public int CompareTo(Edge other)
        {
            return this.len.CompareTo(other.len);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Edge)obj);
        }
    }
}
