using System;
using Task12MST;

namespace Task13SPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(7, 5);

            matrix.AddNode(0, new int[] { 1, 2, 3 });
            matrix.AddNode(1, new int[] { 0, 2, 4 });
            matrix.AddNode(2, new int[] { 0, 1, 3, 4, 5 });
            matrix.AddNode(3, new int[] { 0, 2, 5 });
            matrix.AddNode(4, new int[] { 1, 2, 5, 6 });
            matrix.AddNode(5, new int[] { 2, 3, 4, 6 });
            matrix.AddNode(6, new int[] { 4, 5 });

            matrix.AddEdge(0, 1, 2);
            matrix.AddEdge(0, 2, 3);
            matrix.AddEdge(0, 3, 6);
            matrix.AddEdge(1, 2, 4);
            matrix.AddEdge(1, 4, 9);
            matrix.AddEdge(2, 3, 1);
            matrix.AddEdge(2, 4, 7);
            matrix.AddEdge(2, 5, 6);
            matrix.AddEdge(3, 5, 4);
            matrix.AddEdge(4, 5, 1);
            matrix.AddEdge(4, 6, 5);
            matrix.AddEdge(5, 6, 8);

            var result = matrix.SPFDijkstra();
            foreach(var item in result)
            {
                Console.WriteLine("V : " + item.v1 + " Len : " + item.len + " (" + item.v2 + ")");
            }

            Console.ReadKey();
        }
    }
}
