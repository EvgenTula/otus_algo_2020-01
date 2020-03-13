using SimpleTester;
using System;
using System.Windows;

namespace task1Fibonacci
{
    class MatrixMultiplication : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            Matrix2d newM = Matrix2d.Pow(new Matrix2d(), num - 1);
            return newM.firstItem().ToString();
        }        
    }

    class Matrix2d
    {
        int[,] arr;

        static Matrix2d DEFAULT
        {
            get
            {
                Matrix2d result = new Matrix2d();
                result.arr = new int[,] { { 1, 0 }, { 1, 0 } };
                return result;
            }
        }
        
        public Matrix2d()
        {
            arr = new int[,] { { 1, 1 },
                               { 1, 0 } };

        }
        public static Matrix2d operator *(Matrix2d m1, Matrix2d m2)
        {
            Matrix2d result = new Matrix2d();

            for (int i = 0; i < m1.arr.GetLength(0); i++)
            {
                for (int j = 0; j < m1.arr.GetLength(1); j++)
                {
                    result.arr[i, j] = 0;
                    for (int k = 0; k < m1.arr.GetLength(1); k++)
                    {
                        result.arr[i, j] += m1.arr[i, k] * m2.arr[k, j];
                    }
                }

            }
            return result;
        }

        public static Matrix2d Pow(Matrix2d matrix2D, int pow)
        {
            Matrix2d result = Matrix2d.DEFAULT;
            while (pow > 1)
            {
                if (pow % 2 == 1)
                    result = result * matrix2D;
                matrix2D = matrix2D * matrix2D;
                pow /= 2;                
            }
            
            if (pow > 0)
                result = result * matrix2D;
            
            return result;       
        }

        public int firstItem()
        {
            return this.arr[0, 0];
        }      
    }

}
