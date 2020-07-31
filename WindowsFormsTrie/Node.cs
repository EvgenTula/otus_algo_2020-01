using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsTrie
{
    public class Node
    {
        public bool isWord;
        public char symbol;
        public Node parent;

        public HashSet<Node> childsWithWords = new HashSet<Node>();
        public Dictionary<char, Node> childs
        {
            private set;
            get;
        }

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

        public Node GetFirst()
        {
            return this.childs.Values.FirstOrDefault();
        }

        public Node GetChild(char val)
        {
            Node result;
            if (!childs.TryGetValue(val, out result))
            {
                result = new Node(val, prefix);
                result.parent = this;
                childs.Add(val, result);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Node node &&
                   isWord == node.isWord &&
                   symbol == node.symbol &&
                   EqualityComparer<Node>.Default.Equals(parent, node.parent) &&
                   prefix == node.prefix;
        }

        public override int GetHashCode()
        {
            int hashCode = 268269044;
            hashCode = hashCode * -1521134295 + isWord.GetHashCode();
            hashCode = hashCode * -1521134295 + symbol.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Node>.Default.GetHashCode(parent);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(prefix);
            return hashCode;
        }
    }
}
