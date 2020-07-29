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

        public List<string> addWorlds = new List<string>();

        public void Add(string str)
        {
            Add(root, str);
            count++;
            addWorlds.Add(str);
        }

       
        private void Add(Node node, string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                node.isWord = true;
                Node tmp = node;
                while (tmp.parent != null)
                {
                    tmp = tmp.parent;
                    tmp.childsWithWords.Add(node);
                }
            }    
            else
            {
                char symbol = str[0];
                var current = node.GetChild(symbol);
                Add(current, str.Substring(1));
            }
        }

        public StringBuilder Search(string str)
        {
            return Search(root, str);
        }

        private StringBuilder Search(Node node, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                StringBuilder words = new StringBuilder();
                if (node.isWord)
                    words.Append(node.prefix + "\n");

                foreach (var item in node.childsWithWords)
                {
                    words.Append(item.prefix + "\n");
                }     
                return words;
            }
            else
            {                
                var current = node.GetChild(str[0]);
                return Search(current, str.Substring(1));
            }   
        }
    }
}
