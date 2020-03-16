using SimpleTester;
using System;
using System.IO;

namespace task2King
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir + "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");

            Task task1 = new King();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("Прогулка Короля - BITS (King)");
            
            Console.ReadKey();
        }
    }
}
