using System;

namespace Task9Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashtableChain<int> customHashtable = new HashtableChain<int>(100);
            int count = 1000;
            Random rnd = new Random();
            for(int i = 0; i < count; i++)
            {
                int key = rnd.Next(count);
                customHashtable.insert(new Node<int>(key, i));
            }

            Console.ReadKey();
        }
    }
}
