using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsTrie
{
    public class Trie
    {
        public int count
        {
            get;
            private set;            
        }

        Node root;

        public Trie()
        {
            root = new Node('\0');
            count = 1;
        }

        public void Add(string str)
        {
            Add(root, str);
            count++;
        }

        private void Add(Node node, string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                node.isWord = true;
            }    
            else
            {
                char symbol = str[0];
                var current = node.GetChild(symbol);
                Add(current, str.Substring(1));
            }
        }

        public string Search(string str)
        {
            return Search(root, str);
        }

        private string Search(Node node, string str)
        {                                   
            if (string.IsNullOrEmpty(str))
            {
                StringBuilder words = new StringBuilder();
                if (node.isWord)
                    words.Append(node.prefix + "\n");
                
                List<Node> nodes = node.GetNodes();
                foreach (var childNode in nodes)
                {
                    //if (childNode.isWord)
                    words.Append(childNode.prefix+"\n");
                }
                return words.ToString();
            }
            else
            {
                var current = node.GetChild(str[0]);
                return Search(current, str.Substring(1));
            }   
        }
    }
}
