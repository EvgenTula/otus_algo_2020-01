using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Task6Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree<int> tree = new BinaryTree<int>();
            AVLTree<int> tree = new AVLTree<int>();           
            int size = 1000000;
            //int size = 100000;
            List<int> list = new List<int>();

            Random rnd = new Random();            
            /*
            for (int i = 0; i < size; i++)
            {
                int newVal = 0;
                while (list.Contains(newVal))
                {
                    newVal = rnd.Next(int.MaxValue);
                }
                list.Add(newVal);
            }
            */
            
            list = Enumerable.Range(0, size).ToList();
            Console.WriteLine("list completed");
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var item in list)
            {
                tree.insert(item);
            }
            sw.Stop();
            Console.WriteLine($"Test #0\t time: {sw.ElapsedMilliseconds}");

            int[] random_index = new int[size / 10];
            for(int i = 0; i < random_index.Length; i++)
            {
                random_index[i] = rnd.Next(size);
            }
            sw.Restart();
            for (int i = 0; i < random_index.Length; i++)
            {
                tree.search(list[random_index[i]]);
            }
            sw.Stop();
            Console.WriteLine($"Test #1\t time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            for (int i = 0; i < random_index.Length; i++)
            {
                tree.remove(list[random_index[i]]);
            }
            sw.Stop();
            Console.WriteLine($"Test #2\t time: {sw.ElapsedMilliseconds}");

            Console.ReadKey();
        }
    }
}
