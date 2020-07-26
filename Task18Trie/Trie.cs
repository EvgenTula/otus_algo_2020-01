﻿using System;
using System.Collections.Generic;

namespace Task18Trie
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
                if (node.isWord)
                    return node.prefix;

                Node result = node.GetNextChild();
                while (result != null && !result.isWord)
                {
                    result = result.GetNextChild();
                }
                if (result == null)
                    return "not fount";
                else
                    return node.prefix;
            }
            else
            {
                var current = node.GetChild(str[0]);
                return Search(current, str.Substring(1));
            }   
        }
    }
}
