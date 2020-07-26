using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsTrie
{
    public class Node
    {
        public bool isWord;
        public char symbol;
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
                childs.Add(val, result);
            }
            return result;
        }
        
        public List<Node> GetNodes()
        {
            return fill(this);
        }

        private List<Node> fill(Node node)
        {
            List<Node> result = new List<Node>();
            Queue<Node> q = new Queue<Node>();

            foreach(var item in node.childs)
            {
                if (item.Value.childs.Count > 0)
                    q.Enqueue(item.Value);
                if (item.Value.isWord)
                    result.Add(item.Value);
            }

            while (q.Count > 0)
            {

                var tmp_node = q.Dequeue();
                result.AddRange(fill(tmp_node));
            }

            return result;
        }     
    }
}
