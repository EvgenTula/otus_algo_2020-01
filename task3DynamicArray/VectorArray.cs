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
            this.capacity = 100;
            array = new T[this.capacity];
        }

        public VectorArray(int capacity)
        {
            this.capacity = capacity;
            array = new T[this.capacity];                    
        }

        public void Add(T item)
        {
            Add(item, Size());
            /*
            if (Size() == array.Length)
                array = ((IArray<T>)this).Resize(array, capacity);
            
            array[Size()] = item;
            size++;
            */
        }

        public void Add(T item, int index)
        {
            
            T[] newArray = null;
            if (Size() == array.Length)
                newArray = new T[Size() + capacity];
            else
                newArray = new T[array.Length];
            Array.Copy(array, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(array, index, newArray, index + 1, Size() - index);
            //Array.Copy(array, index, newArray, index + 1, array.Length - index);
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
            size--;
            Array.Copy(array, index + 1, array, index, Size() - index);
            array[size] = default(T);
            return result;
        }

        public int Size()
        {
            return size;
        }
    }
}
