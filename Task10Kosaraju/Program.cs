using System;

namespace Task10Kosaraju
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(8, 3);
            matrix.add(0, new int[] { 1 });
            matrix.add(1, new int[] { 2, 4, 5 });
            matrix.add(2, new int[] { 3, 6 });
            matrix.add(3, new int[] { 2, 7 });
            matrix.add(4, new int[] { 0, 5 });
            matrix.add(5, new int[] { 6 });
            matrix.add(6, new int[] { 5 });
            matrix.add(7, new int[] { 3, 6 });

            var components = matrix.Component();
            for(int i = 0; i < components.Length; i++)
            {
                Console.WriteLine(i + " component " + components[i]);
            }
            Console.ReadKey();
        }
    }
}
