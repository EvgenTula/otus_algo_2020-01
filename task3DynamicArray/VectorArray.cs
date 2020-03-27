using System;
using System.Collections.Generic;
using System.Text;

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
            if (Size() == array.Length)
                array = ((IArray<T>)this).Resize(array, capacity);
            
            array[Size()] = item;
            size++;
        }

        public void Add(T item, int index)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public T Remove(int index)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            return size;
        }
    }
}
