using System;
using System.Collections.Generic;
using System.Text;

namespace task3DynamicArray
{
    class FactorArray<T> : IArray<T>
    {
        private T[] array;
        private int capacity;
        private int size;
        public FactorArray()
        {
            array = new T[0];
            this.capacity = 100;
        }

        public FactorArray(int capacity)
        {
            array = new T[0];
            this.capacity = capacity;
        }

        public void Add(T item)
        {

            if (Size() >= array.Length)
            {
                T[] result = new T[capacity *= 2];
                Array.Copy(array, result, array.Length);
                array = result;
            }

            array[Size()] = item;
            size++;
        }

        public void Add(T item, int index)
        {

            T[] newArray = null;
            if (Size() >= array.Length)
                newArray = new T[capacity *= 2];
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
