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
                        
            Task task2 = new PrimeSimpeSearchOptimization();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("Несколько оптимизаций перебора делителей, с использованием массива");

            Task task3 = new PrimeEratosthene();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("Решето Эратосфена со сложностью O(n log log n) (PrimeEratosthene)");

            Task task4 = new PrimeEratostheneOptimization();
            Tester tester4 = new Tester(task4, currentDir);
            tester4.RunTests("Решето Эратосфена с оптимизацией памяти: битовая матрица, по 32 значения в одном int (PrimeEratostheneOptimization)");

            Task task5 = new PrimeEratostheneN();
            Tester tester5 = new Tester(task5, currentDir);
            tester5.RunTests("Решето Эратосфена со сложностью O(n) (PrimeEratostheneN)");

            Console.ReadKey();
        }
    }
}
