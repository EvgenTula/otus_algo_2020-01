using System;

namespace Task18Trie
{
    public class Trie
    {
        int count;
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
            //if (node.isWord)
            {
            //    return node.prefix;
            }
            //else
            {
                if (string.IsNullOrEmpty(str))
                {
                    if (node.isWord)
                        return node.prefix;
                    Node result = node.GetFirstChild();
                    while (result != null && !result.isWord)
                    {
                        result = result.GetFirstChild();
                    }
                    if (result == null)
                        return "not found!";
                    else
                        return result.prefix;
                }
                else
                {
                    var current = node.GetChild(str[0]);
                    return Search(current, str.Substring(1));
                }
            }   
        }
    }
}
