namespace Task4Sort
{
    class ShellSort
    {
        public int[] array;

        public ShellSort(int[] array)
        {
            this.array = array;
        }

        public virtual void sort()
        {
            for(int i = array.Length / 2; i > 0; i/=2)
            {
                insertionSort(i);
            }
        }
        protected void insertionSort(int step)
        {
            for (int i = step; i < array.Length; i+=step)
            {
                int currentItem = i;
                while (currentItem > 0 && array[currentItem - step] > array[currentItem])
                {
                    int tmp = array[currentItem - step];
                    array[currentItem - step] = array[currentItem];
                    array[currentItem] = tmp;
                    currentItem -= step;
                }
            }

        }
    }
}
