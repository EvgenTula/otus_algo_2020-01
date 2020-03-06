using SimpleTester;
using System;
using System.IO;

namespace task1POW
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();
            
            ITask task1 = new POWFullMultiplication();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Итеративный (n умножений)");
            
            ITask task2 = new POWPartialMultiplication();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("Через степень двойки с домножением");

            
            ITask task3 = new POWDecomposition();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("Через двоичное разложение показателя степени");
            

            Console.ReadKey();
        }
    }
}
