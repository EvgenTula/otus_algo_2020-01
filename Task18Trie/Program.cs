using System;
using System.ComponentModel.Design;
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

            string inputStr = String.Empty;
            while (inputStr != "exit")
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                
                if (Char.IsLetter(keyInfo.KeyChar))
                    inputStr += keyInfo.KeyChar.ToString();
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    //inputStr = inputStr.Substring(0, inputStr.Length - 1);


                    
                    Console.Write("");
                }
                if (keyInfo.Key == ConsoleKey.Tab)
                    Console.Write(trie.Search(inputStr));               
            }
            Console.ReadKey();
        }
    }
}
