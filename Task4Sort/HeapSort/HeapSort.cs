namespace Task4Sort
{
    class HeapSort
    {
        public int[] array;

        public HeapSort(int[] array)
        {
            this.array = array;
        }

        public void sort()
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                max(i, array.Length);
            }
            
            for (int i = array.Length - 1; i >= 0; i--)
            {
                swap(0, i);
                max(0, i);                
            }
        }
       

        private void max(int root, int length)
        {
            int indexL = root * 2 + 1;
            int indexR = indexL + 1;
            int maxIndex = root;
            if (indexL < length && array[indexL] > array[maxIndex])
            {
                maxIndex = indexL;
            }
            if (indexR < length && array[indexR] > array[maxIndex])
            {
                maxIndex = indexR;
            }
            if (maxIndex == root)
            {
                return;
            }
            swap(maxIndex, root);
            max(maxIndex, length);
        }

        private void swap(int a, int b)
        {
            int tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }
    }
}
