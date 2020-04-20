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
            /*
            string str = File.ReadAllText(@"C:\dev\otus_algo_2020-01\Task4Sort\Test\test.0.in");
            int[] array = Array.ConvertAll(str.Split(" "), s => int.Parse(s));

            Array.Sort(array);
            int cntIntem = array.Length / 100 * 5;
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = array.Length - cntIntem; i < array.Length; i++)
            {
                array[i] = random.Next(array.Length);
                
            }
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i] + " ");
                if (stringBuilder.Capacity - 500 == stringBuilder.MaxCapacity)
                {
                    File.AppendAllText(@"C:\dev\otus_algo_2020-01\Task4Sort\Test\test.1.in", stringBuilder.ToString());
                    stringBuilder.Clear();
                }


            }
            

            File.AppendAllText(@"C:\dev\otus_algo_2020-01\Task4Sort\Test\test.1.in", stringBuilder.ToString());

            stringBuilder.Clear();
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i] + " ");
                if (stringBuilder.Capacity - 5000 == stringBuilder.MaxCapacity)
                {
                    File.AppendAllText(@"C:\dev\otus_algo_2020-01\Task4Sort\Test\test.1.out", stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            File.AppendAllText(@"C:\dev\otus_algo_2020-01\Task4Sort\Test\test.1.out", stringBuilder.ToString());
            */
            
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
