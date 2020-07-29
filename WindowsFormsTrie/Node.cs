using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsTrie
{
    public class Node
    {
        public bool isWord;
        public char symbol;
        public Node parent;

        public List<Node> childsWithWords = new List<Node>();
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
                childsWithWords.Add(result);
            }
            return result;
        }     
    }
}
