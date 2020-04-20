using SimpleTester;
using System;
using System.Text;

namespace Task4Sort
{
    class HeapSortTask : Task
    {
        public override string Run(string[] data)
        {
            int[] array = Array.ConvertAll(data[0].Split(" "), s => int.Parse(s));
            StringBuilder stringBulder = new StringBuilder();
            HeapSort heapSort = new HeapSort(array);
            heapSort.sort();
            foreach (var item in heapSort.array)
            {
                stringBulder.Append(item + " ");
            }
            return stringBulder.ToString().TrimEnd();
        }
    }
}
