using System;
using System.Collections.Generic;
using System.Text;

namespace Task5Sort
{
    public class RadixSort
    {

        public void sort(int[] arr, int maxRadix)
        {
            int cnt = arr.Length;
            
            int[] result = new int[arr.Length];
            for (int i = maxRadix - 1; i >= 0; i--)
            {
                int[] radix = new int[10];
                for (int j = 0; j < arr.Length; j++)
                {
                    String num = arr[j].ToString("D" + maxRadix);                    
                    radix[Int32.Parse(num[i].ToString())]++;
                }

                for (int j = 1; j < radix.Length; j++)
                {
                    radix[j] = radix[j] + radix[j - 1];
                }

                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    String num = arr[j].ToString("D" + maxRadix);
                    
                    radix[Int32.Parse(num[i].ToString())]--;
                    result[radix[Int32.Parse(num[i].ToString())]] = arr[j];
                }


                for(int j = 0; j < arr.Length; j++)
                {
                    arr[j] = result[j];
                }
            }
        }

    }
}
