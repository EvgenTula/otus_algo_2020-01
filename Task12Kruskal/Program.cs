using System;

namespace Task12MST
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(7, 5);
            matrix.AddNode(0, new int[] { 1, 3 });
            matrix.AddNode(1, new int[] { 2, 3, 4 });
            matrix.AddNode(2, new int[] { 1, 4 });
            matrix.AddNode(3, new int[] { 0, 1, 4, 5 });
            matrix.AddNode(4, new int[] { 1, 2, 3, 5, 6 });
            matrix.AddNode(5, new int[] { 3, 4 });
            matrix.AddNode(6, new int[] { 4, 5 });

            matrix.AddEdge(0, 1, 7);
            matrix.AddEdge(0, 3, 5);
            matrix.AddEdge(1, 2, 8);
            matrix.AddEdge(1, 3, 9);
            matrix.AddEdge(1, 4, 7);
            matrix.AddEdge(2, 4, 5);
            matrix.AddEdge(3, 4, 15);
            matrix.AddEdge(3, 5, 6);
            matrix.AddEdge(4, 5, 8);
            matrix.AddEdge(4, 6, 9);
            matrix.AddEdge(5, 6, 11);

            var mst = matrix.GetMST();
            foreach(var item in mst)
            {
                if (item != null)
                    Console.WriteLine(item.v1 + " - " + item.v2 + " (" + item.len + ")");
            }

            Console.ReadKey();


        }
    }
}
