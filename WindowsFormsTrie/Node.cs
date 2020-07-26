using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsTrie
{
    public class Node
    {
        public bool isWord;
        public char symbol;
        private Dictionary<char, Node> childs;
        public string prefix;

        private IEnumerator enumerator;

        public Node(char val)
        {
            symbol = val;
            childs = new Dictionary<char, Node>();
        }

        private Node(char val, string prefix)
        {
            symbol = val;
            childs = new Dictionary<char, Node>();
            this.prefix = prefix + val;
        }

        public Node GetChild(char val)
        {
            Node result;
            if (!childs.TryGetValue(val, out result))
            {
                result = new Node(val, prefix);
                childs.Add(val, result);
                enumerator = childs.GetEnumerator();
            }
            return result;
        }
        
        public Node GetNextChild()
        {          
            if (enumerator != null && enumerator.MoveNext())
                return ((KeyValuePair<char, Node>)enumerator.Current).Value;
            return null;
        }

        public void ResetEnumerator()
        {
            if (enumerator != null)
                enumerator.Reset();
        }
    }
}
