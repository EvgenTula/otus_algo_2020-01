using System;
using task1NOD;
using SimpleTester;
using System.IO;

namespace Task1NOD
{
    class Program
    {
        static void Main(string[] args)
        {            
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir+ "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");
            
            Task task1 = new NODSubtract();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Через вычитание");
                    
            Task task2= new NODDiv();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("Через остаток");
            
            Task task3 = new NODShift();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("Через битовые операции");
            
            Console.ReadKey();
        }
    }
}
