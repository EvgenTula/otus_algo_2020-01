using System.Globalization;
using System.Runtime.Intrinsics;
using System.Threading;
using task3DynamicArray;

namespace Task12MST
{ 
    public class Matrix
    {
        public object[,] arr;
        public SingleArray<Edge> edges;
        public Matrix(int n, int max)
        {
            arr = new object[n, max];
            edges = new SingleArray<Edge>();
        }

        public void AddNode(int n, int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                arr[n, i] = vector[i];
            }
        }

        public void AddEdge(int v1, int v2, int len)
        {
            edges.Add(new Edge(v1, v2, len));
        }

        public Edge[] SPFDijkstra()
        {
            Edge[] result = new Edge[arr.GetLength(0)];

            bool[] visited = new bool[arr.GetLength(0)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Edge(i, -1, int.MaxValue);
            }
            result[0].v2 = result[0].v1;
            result[0].len = 0;

            Edge item;
            while ((item = GetMinNode(ref result,ref visited)) != null)
            {
                if (!visited[item.v1])
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[item.v1, j] == null)
                            continue;
                        int node = (int)arr[item.v1, j];
                        if (!visited[node])
                        {
                            var edge = Find(item.v1, node);
                            if (item.len + edge.len < result[node].len)
                            {
                                result[node].v2 = item.v1;
                                result[node].len = item.len + edge.len;
                            }
                        }
                    }
                    visited[item.v1] = true;
                }
            }
            return result;        
        }

        private Edge GetMinNode(ref Edge[] edges, ref bool[] visited)
        {
            Edge result = null;
            for(int i = 0; i < edges.Length; i++)
            {                
                if (!visited[edges[i].v1])
                {
                    if (result == null)
                    {
                        result = edges[i];
                    }
                    else
                    {
                        if (result.len > edges[i].len)
                        {
                            result = edges[i];
                        }
                    }
                }
            }
            return result;
        }

        private Edge Find(int v1, int v2)
        {
            foreach(var item in edges)
            {
                if ((item.v1 == v1 && item.v2 == v2) ||
                    item.v1 == v2 && item.v2 == v1)
                    return item;
            }
            return null;
        }
    }
}
