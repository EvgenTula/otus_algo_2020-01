using System;

namespace Task6Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.insert(100);
            binaryTree.insert(50);
            binaryTree.insert(40);
            binaryTree.insert(60);
            binaryTree.insert(150);
            binaryTree.insert(140);
            binaryTree.insert(160);
            binaryTree.insert(35);
            binaryTree.insert(45);
            binaryTree.insert(44);
            binaryTree.insert(46);
            binaryTree.insert(33);
            binaryTree.insert(37);
            binaryTree.insert(55);
            binaryTree.insert(65);
            binaryTree.insert(70);
            binaryTree.insert(54);
            binaryTree.insert(56);
            binaryTree.insert(53);
            binaryTree.insert(52);
            binaryTree.insert(36);
            binaryTree.insert(34);
            binaryTree.insert(32);
            binaryTree.insert(165);
            binaryTree.insert(155);
            binaryTree.insert(154);
            binaryTree.insert(153);
            binaryTree.insert(170);
            binaryTree.insert(163);
            binaryTree.insert(164);
            binaryTree.insert(162);
            binaryTree.insert(158);
            binaryTree.insert(159);
            binaryTree.insert(157);
            binaryTree.insert(156);

            //binaryTree.remove(32);
            //binaryTree.remove(37);
            //binaryTree.remove(40);


            //binaryTree.remove(159);
            //binaryTree.remove(154);
            //binaryTree.remove(160);

            /*
            bool searchResult = binaryTree.search(100);
            Console.WriteLine("searchResult:\t" + searchResult);
            searchResult = binaryTree.search(160);
            Console.WriteLine("searchResult:\t" + searchResult);
            searchResult = binaryTree.search(40);
            Console.WriteLine("searchResult:\t" + searchResult);
            searchResult = binaryTree.search(-1);
            Console.WriteLine("searchResult:\t" + searchResult);
            */

            Console.ReadKey();
        }
    }
}
