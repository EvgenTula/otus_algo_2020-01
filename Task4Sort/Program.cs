using SimpleTester;
using System;
using System.IO;
using System.Text;

namespace Task4Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir + "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");

            Task task1 = new ShellSortTask();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("ShellSort (Shell, 1959)");

            Task task2 = new ShellSortTask1();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("ShellSort (Sedgewick, 1986)");

            Task task3 = new ShellSortTask();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("ShellSort (Tokuda, 1992)");

            Task task4 = new HeapSortTask();
            Tester tester4 = new Tester(task2, currentDir);
            tester4.RunTests("HeapSort");

            Console.ReadKey();
            
        }
    }
}
