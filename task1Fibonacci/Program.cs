using SimpleTester;
using System;
using System.IO;

namespace task1Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();
            /*
            Task task1 = new Recursive();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Через рекурсию (Recursive)");
            */
            
            /*
            Task task2 = new Iteration();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("Через итерацию (Iteration)");
            */

            /*
            Task task3 = new GoldenRatio();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("По формуле золотого сечения (GoldenRatio)");
            */


            
            Task task4 = new MatrixMultiplication();
            Tester tester4 = new Tester(task4, currentDir);
            tester4.RunTests("Через умножение матриц (MatrixMultiplication)");                      

            Console.ReadKey();
        }
    }
}
