using System;
using System.Collections.Generic;
using System.Text;

namespace Task5Sort
{
    class MergeSort
    {
        public void sort(int[] array)
        {
            mergesort(array, 0, array.Length - 1);
        }

        void mergesort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int center = left + (right - left) / 2;
            mergesort(arr, left, center);
            mergesort(arr, center + 1, right);
            merge(arr, left, center, right);
        }

        void merge(int[] A, int left, int center, int right)
        {
            int[] result = new int[right - left + 1];
            int a = left;
            int b = center + 1;         
            int r = 0;
            while (a <= center && b <= right)
            {
                if (A[a] < A[b])
                {
                    result[r++] = A[a++];
                }
                else
                {
                    result[r++] = A[b++];
                }
            }

            while (a <= center)
                result[r++] = A[a++];
            while (b <= right)
                result[r++] = A[b++];
            for(int i = left; i <= right; i++)
            {
                A[i] = result[i - left];
            }

        }      
    }
}
