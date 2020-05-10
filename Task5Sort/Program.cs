using SimpleTester;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Task5Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestsCreator.Create(100_000, 1, @"C:\dev\otus_algo_2020-01\Task5Sort\Test\", true);
            //TestsCreator.Create(1_000_000, 2, @"C:\dev\otus_algo_2020-01\Task5Sort\Test\", true);
            //TestsCreator.Create(10_000_000, 3, @"C:\dev\otus_algo_2020-01\Task5Sort\Test\", true);
            
            SortFile mergeSort = null;

            Stopwatch sw = Stopwatch.StartNew();
            
            Console.WriteLine("MergreSort");
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.1.in", 100_000))
            {
                mergeSort.MergreSort();
            }
            sw.Stop();
            Console.WriteLine($"Test #0\t time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.2.in", 1_000_000))
            {
                mergeSort.MergreSort();
            }
            sw.Stop();
            Console.WriteLine($"Test #1\t time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.3.in", 10_000_000))
            {
                mergeSort.MergreSort();
            }
            sw.Stop();
            Console.WriteLine($"Test #2\t time: {sw.ElapsedMilliseconds}");
            Console.WriteLine("QuicksorMergetSort(50)");
            sw.Restart();
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.1.in", 100_000))
            {
                mergeSort.QuicksorMergetSort(50);
            }
            sw.Stop();
            Console.WriteLine($"Test #0\t time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.2.in", 1_000_000))
            {
                mergeSort.QuicksorMergetSort(50);
            }
            sw.Stop();
            Console.WriteLine($"Test #1\t time: {sw.ElapsedMilliseconds}");

            sw.Restart();
            using (mergeSort = new SortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.3.in", 10_000_000))
            {
                mergeSort.QuicksorMergetSort(50);
            }
            sw.Stop();
            Console.WriteLine($"Test #2\t time: {sw.ElapsedMilliseconds}");
            
            Console.WriteLine("RadixSort");
            //sw.Restart();
            using (RadixSortFile radixSort = new RadixSortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.1.in", 100_000))
            {
                radixSort.sort();
            }
            sw.Stop();
            Console.WriteLine($"Test #0\t time: {sw.ElapsedMilliseconds}");
            sw.Restart();
            using (RadixSortFile radixSort = new RadixSortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.2.in", 1_000_000))
            {
                radixSort.sort();
            }
            sw.Stop();
            Console.WriteLine($"Test #1\t time: {sw.ElapsedMilliseconds}");
            sw.Restart();
            using (RadixSortFile radixSort = new RadixSortFile(@"C:\dev\otus_algo_2020-01\Task5Sort\Test\test.3.in", 10_000_000))
            {
                radixSort.sort();
            }
            sw.Stop();
            Console.WriteLine($"Test #2\t time: {sw.ElapsedMilliseconds}");
            Console.ReadKey(); 
            
        }

       
    }
}
