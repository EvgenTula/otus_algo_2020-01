using SimpleTester;
using System;
using System.IO;

namespace task2Truckers
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir + "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");

            Task task1 = new Truckers();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Дальнобойщики - BITS (Truckers)");

            Console.ReadKey();
        }
    }
}
