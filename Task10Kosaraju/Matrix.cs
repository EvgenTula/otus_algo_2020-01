namespace Task10Kosaraju
{
    public class Matrix
    {
        public object[,] arr;
        public Matrix(int n, int max)
        {
            arr = new object[n,max];           
        }

        public void add(int n, int[] vector)
        {
            for(int i = 0; i < vector.Length; i++)
            {
                arr[n, i] = vector[i];
            }
        }

        private Matrix Reverse()
        {
            Matrix matrix = new Matrix(arr.GetLength(0), arr.GetLength(1));
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {                    
                    if (arr[i, j] == null)
                        break;
                    int k = 0;
                    int index = (int)arr[i, j];
                    while (matrix.arr[index, k] != null)
                        k++;
                    matrix.arr[index, k] = i;
                }                
            }
            return matrix;
        }

        public int[] orderDFS()
        {
            bool[] visited = new bool[arr.GetLength(0)];
            int[] orderResult = new int[arr.GetLength(0)];       
            int numOrder = 0;
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    orderDFS(i);
                    orderResult[i] = ++numOrder;
                }       
            }
            return prepareResult();

            void orderDFS(int node)
            {
                visited[node] = true;
                int i = 0;
                for(int k = 0; k < arr.GetLength(1); k++)
                {
                    if (arr[node, k] == null)
                        break;
                    int val = (int)arr[node, k];
                    if (!visited[val])
                    {
                        orderDFS(val);
                        orderResult[val] = ++numOrder;
                    }                    
                    i++;
                }                
            }

            int[] prepareResult()
            {
                int index = 0;
                int[] result = new int[orderResult.GetLength(0)];
                while (numOrder > 0)
                {
                    for (int i = 0; i < orderResult.GetLength(0); i++)
                    {
                        if (orderResult[i] == numOrder)
                        {
                            result[index++] = i;
                            numOrder--;
                            break;
                        }
                    }
                }
                return result;
            }
        }


        public int[] Component()
        {
            Matrix reverseMatrix = Reverse();
            var order = reverseMatrix.orderDFS();
            int[] result = new int[order.Length];
            
            bool[] visited = new bool[order.GetLength(0)];
            int componentNum = 1;
            for (int i = 0; i < order.Length; i ++)
            {
                if (!visited[order[i]])
                {
                    resultDFS(order[i], componentNum, ref visited, ref result);
                    result[order[i]] = componentNum;
                    componentNum++;
                }
            }
            
            return result;
        }

        private void resultDFS(int node, int componentNum, ref bool[] visited, ref int[] result)
        {
            visited[node] = true;

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (arr[node, i] == null)
                    break;
                int val = (int)arr[node, i];
                if (!visited[val])
                {
                    resultDFS(val, componentNum, ref visited, ref result);
                    result[val] = componentNum;
                }
            }
        }
    }
}
