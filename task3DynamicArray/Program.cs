using SimpleTester;
using System;
using System.Diagnostics;
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

            //IArray<String> array = new MatrixArray<String>();
            
            //Stopwatch sw = Stopwatch.StartNew();
            //addValues(array, 100000);
            //sw.Stop(); 
            
            //Stopwatch sw = Stopwatch.StartNew();
            //getValues(array, 100000);
            //sw.Stop();

            //Stopwatch sw = Stopwatch.StartNew();
            //removeValues(array);
            //sw.Stop();
            
            //Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
        
        //static void addValues(IArray<String> array, int count)
        //{
        //    //Random random = new Random();
        //    for(int i = 0; i < count; i++)
        //    {
        //        array.Add(i + "");
        //        //array.Add(i + "", random.Next(0, array.Size()));
        //        //array.Add(i + "", array.Size()-1);
        //    }
        //}

        //static void getValues(IArray<String> array, int count)
        //{
        //    //Random random = new Random();
        //    for (int i = 0; i < count; i++)
        //    {
        //        array.Get(0);
        //        //array.Get(random.Next(0, array.Size()));
        //        //array.Get(array.Size()-1);
        //    }
        //}

        //static void removeValues(IArray<String> array)
        //{
        //    //Random random = new Random();
        //    while (array.Size() > 0)
        //    {
        //        array.Remove(0);
        //        //array.Remove(random.Next(0, array.Size()));
        //        //array.Remove(array.Size()-1);                
        //    }
        //}
    }
}
