using SimpleTester;
using System;
using System.IO;
using System.Text;

namespace task3DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("..\\..\\..\\Test");
            String currentDir = Directory.GetCurrentDirectory();

            if (File.Exists(currentDir + "\\Result.md"))
                File.Delete(currentDir + "\\Result.md");

            Task task1 = new SingleArrayTask();
            Tester tester1 = new Tester(task1, currentDir);
            tester1.RunTests("SingleArray");
            
            Task task2 = new VectorArrayTask();
            Tester tester2 = new Tester(task2, currentDir);
            tester2.RunTests("VectorArray");
            
            Task task3 = new FactorArrayTask();
            Tester tester3 = new Tester(task3, currentDir);
            tester3.RunTests("FactorArray");

            Task task4 = new MatrixArrayTask();
            Tester tester4 = new Tester(task3, currentDir);
            tester3.RunTests("MatrixArray");

            Console.ReadKey();
        }

        static void addValues(IArray<String> array, int count)
        {
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < count; i++)
            {
                res.Append(i + " ");
                //array.Add(i + "");
            }
        }

        static void getValues(IArray<String> array, int count)
        {

        }
       
    }
}
