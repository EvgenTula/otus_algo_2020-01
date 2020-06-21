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

        public Matrix Reverse()
        {
            Matrix matrix = new Matrix(arr.GetLength(0), arr.GetLength(1));
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {                    
                    if (this.arr[i, j] == null)
                        break;
                    int k = 0;
                    int index = (int)this.arr[i, j];
                    while (matrix.arr[index, k] != null)
                        k++;
                    matrix.arr[index, k] = i;
                }                
            }
            return matrix;
        }

        public int[,] dfs(int node)
        {

        }

        public object[] Component()
        {
            return null;
        }
    }
}
