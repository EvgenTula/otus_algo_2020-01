using SimpleTester;
using System;
using System.IO;

namespace task2FEN
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir + "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");

            Task task1 = new Fen();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("FEN - BITS (Fen)");

            Console.ReadKey();
        }
    }
}
