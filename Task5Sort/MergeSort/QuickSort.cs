using System;
using System.Collections.Generic;
using System.Text;

namespace Task5Sort
{
    class QuickSort
    {
        public void sort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
        private int partition(int[] arr, int left, int right)
        {
            int i = left - 1;
            int pivot = arr[right];
            for (int j = left; j <= right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            return i;
        }

        private void quicksort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int center = partition(arr, left, right);
            quicksort(arr, left, center - 1);
            quicksort(arr, center + 1, right);
        }
    }
}
