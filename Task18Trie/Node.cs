using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task18Trie
{
    public class Node
    {
        public bool isWord;
        public char symbol;
        private Dictionary<char, Node> childs;
        public string prefix;

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
            }
            return result;
        }

        public Node GetFirstChild()
        {
            if (childs.Count == 0)
                return null;
            return childs.First().Value;
        }
    }
}
