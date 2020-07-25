using System;
using System.IO;

namespace Task18Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            string[] data = File.ReadAllLines(@"D:\dev\otus_algo_2020-01\Task18Trie\data\russian_nouns.txt");
            for(int i = 0; i < data.Length; i++)
            {
                trie.Add(data[i]);
            }

            string str;
            while ((str = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(trie.Search(str));
            }
            Console.ReadKey();
        }
    }
}
