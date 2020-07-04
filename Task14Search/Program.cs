using System;

namespace Task14Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Searcher searcher = new Searcher();
            //string text = "SOMETEXT";
            //string pattern = "TEXT";
            string text = "aaBaaaBaaaaaaBaaaBaaaaB";
            string pattern = "aaBaaaBaaaaB";

            Console.WriteLine(searcher.BM(text, pattern));
            Console.WriteLine(searcher.KMP(text, pattern));
            //string text = "aaBaaaBaaaaaaBaaaBaaaaB";
            //string pattern = "aaBaaaBaaaaB";
            //string text = "AABAAABAAAAAABAAABAAAAB";
            //string pattern = "AABAAABAAAAB";
            //var a = searcher.CreateSuffix("abcdadcd");
            //var b = searcher.CreateSuffix("колокол");
            Console.ReadKey();
        }
    }
}
