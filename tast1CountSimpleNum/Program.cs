using SimpleTester;
using System;
using System.IO;

namespace tast1Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();
            
            Task task1 = new PrimeSimpeSearch();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Через перебор делителей (PrimeSimpeSearch)");
            /*
            Task task2 = new PrimeSimpeSearchOptimization();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("Несколько оптимизаций перебора делителей, с использованием массива");

            */


            /*
            Task task3 = new POWDecomposition();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("Через двоичное разложение показателя степени (POWDecomposition)");
            */
            Console.ReadKey();
        }
    }
}
