using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;
using task3DynamicArray;

namespace Task11TopologicalSort
{
    public class Matrix
    {
        public object[,] arr;
        public Matrix(int n, int max)
        {
            arr = new object[n, max];
        }

        public void add(int n, int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                arr[n, i] = vector[i];
            }
        }

        public int?[,] TopologicalSort()
        {           
            int[,] table = GetTableLinks();
            int?[,] result = new int?[table.GetLength(0), table.GetLength(1)];
            bool[] visited = new bool[table.GetLength(0)];
            int[] m = new int[table.GetLength(0)];
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i,j] == 1)
                    {
                        m[j] += 1;
                    }
                }
            }
            SingleArray<int> arrayToProcess;
            int lvl = 0;
            while ((arrayToProcess = ItemToVisit(m, visited)).Size() > 0)
            {
                int num = 0;
                foreach (var item in arrayToProcess)
                {                   
                    for (int i = 0; i < m.Length; i++)
                    {
                        m[i] = m[i] - table[item, i];
                    }
                    visited[item] = true;
                    result[lvl, num++] = item;
                }
                lvl++;
            }
            return result;
        }

        private SingleArray<int> ItemToVisit(int[] m, bool[] visited)
        {
            SingleArray<int> singleArray = new SingleArray<int>();
            for (int i = 0; i < m.Length; i++)
            {
                if (visited[i] == false && m[i] == 0)
                {
                    singleArray.Add(i);
                }
            }
            return singleArray;
        }

        private int[,] GetTableLinks()
        {
            int n = arr.GetLength(0);
            int[,] table = new int[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] != null)
                    {
                        int index = (int)arr[i, j];
                        table[i, index] = 1;
                    }
                }
            }
            return table;
        }
    }
}
