using System;

namespace task3DynamicArray
{
    class VectorArray<T> : IArray<T>
    {
        private T[] array;
        private int capacity;
        private int size;
        public VectorArray()
        {
            array = new T[0];
            this.capacity = 100;           
        }

        public VectorArray(int capacity)
        {
            array = new T[0];
            this.capacity = capacity;            
        }

        public void Add(T item)
        {
            
            if (Size() >= array.Length)
                array = ((IArray<T>)this).Resize(array, capacity);
            
            array[Size()] = item;
            size++;
        }

        public void Add(T item, int index)
        {
            
            T[] newArray = null;
            if (Size() >= array.Length)
                newArray = new T[Size() + capacity];
            else
                newArray = new T[array.Length];
            Array.Copy(array, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(array, index, newArray, index + 1, Size() - index);
            array = newArray;
            size++;
        }

        public T Get(int index)
        {
            return array[index];
        }

        public T Remove(int index)
        {
            T result = Get(index);
            Array.Copy(array, 0, array, 0, index);
            Array.Copy(array, index + 1, array, index, size - (index - 1));
            return result;
        }

        public int Size()
        {
            return size;
        }
    }
}
