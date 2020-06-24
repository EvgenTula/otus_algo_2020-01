using System;
using System.Text;

namespace Task11TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(14,4);
            matrix.add(0, new int[] { 2, 12 });
            matrix.add(1, new int[] { 12 });
            //matrix.add(2, new int[] { });
            matrix.add(3, new int[] { 2 });
            matrix.add(4, new int[] { 2, 8, 9 });
            matrix.add(5, new int[] { 3, 10, 11});
            matrix.add(6, new int[] { 10 });
            matrix.add(7, new int[] { 1, 3, 5, 6 });
            matrix.add(8, new int[] { 0, 13 });
            matrix.add(9, new int[] { 0, 6, 11 });
            matrix.add(10, new int[] { 2 });
            //matrix.add(11, new int[] { });
            matrix.add(12, new int[] { 2 });
            matrix.add(13, new int[] { 5 });

            var result = matrix.TopologicalSort();
            for(int i = 0; i < result.GetLength(0); i++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int j = 0;
                while(result[i,j] != null)
                {
                    stringBuilder.Append(result[i, j] + " ");
                    j++;
                }
                if (stringBuilder.Length > 0)
                    Console.WriteLine("Level " + i + " : " + stringBuilder.ToString() + "\n");
            }

            Console.ReadKey();
        }
    }
}
