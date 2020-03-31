using task3DynamicArray.Queue;

namespace task3DynamicArray
{
    class PriorityQueue<T>
    {
        Queue<T>[] array;
        public PriorityQueue(int priorityCount)
        {
            array = new Queue<T>[priorityCount];
        }
        public void enqueue(int priority, T item)
        {
            if (array[priority] == null)
                array[priority] = new Queue<T>();
            array[priority].Enqueue(item);          
        }
        public T Dequeue()
        {
            int minpriority = 0;
            while (array[minpriority] == null || array[minpriority].IsEmpty() == true)
            {
                minpriority++;
                if (minpriority == array.Length)
                    return default(T);
            }           
            return array[minpriority].Dequeue();                
        }

        public T Peek()
        {
            int minpriority = 0;
            while (array[minpriority] == null || array[minpriority].IsEmpty() == true)
            {
                minpriority++;
            }
            if (minpriority < array.Length)
                return array[minpriority].Peek();
            else
                return default(T);
        }

    }
}
