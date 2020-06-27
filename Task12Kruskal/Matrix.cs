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

        /// <summary>
        /// Алгоритм Крускала
        /// </summary>
        /// <returns></returns>
        public Edge[] GetMST()
        {
            Edge[] result = new Edge[edges.Size()];
            int[] components = new int[arr.GetLength(0)];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = i;
            }
            edges.Sort();

            int componentCount = 0;

            foreach(var item in edges)
            {
                if (merge(item))
                {
                    result[componentCount++] = item;
                }
            }
            return result;


            int GetRootComponent(int index)
            {
                if (components[index] == index)
                {
                    return index;
                }
                else
                {
                    return GetRootComponent(components[index]);
                }
            }

            bool merge(Edge edge)
            {
                int rootV1 = GetRootComponent(edge.v1);
                int rootV2 = GetRootComponent(edge.v2);
                if (rootV1 == rootV2)
                {
                    return false;
                }
                else
                {
                    if (edge.v1 < edge.v2)
                    {
                        int parent = components[edge.v2];                        
                        components[edge.v2] = rootV1;
                        while(components[parent] != rootV1)
                        {
                            int tmp = components[parent];
                            components[parent] = rootV1;
                            parent = tmp;
                        }
                    }
                    else
                    {
                        int parent = components[edge.v1];
                        components[edge.v1] = rootV2;
                        while (components[parent] != rootV2)
                        {
                            int tmp = components[parent];
                            components[parent] = rootV2;
                            parent = tmp;
                        }
                    }
                }
                return true;
            }
        }
    }
}
