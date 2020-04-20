using SimpleTester;
using System;
using System.Text;

namespace Task4Sort
{
    class ShellSortTask : Task
    {
        public override string Run(string[] data)
        {
            int[] array = Array.ConvertAll(data[0].Split(" "), s => int.Parse(s));
            StringBuilder stringBulder = new StringBuilder();
            ShellSort shellSort = new ShellSort(array);
            shellSort.sort();
            foreach (var item in shellSort.array)
            {
                stringBulder.Append(item + " ");
            }
            return stringBulder.ToString().TrimEnd();
        }
    }
}
