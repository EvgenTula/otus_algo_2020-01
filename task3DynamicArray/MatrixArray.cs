using System;
using System.Collections.Generic;
using System.Text;

namespace task3DynamicArray
{
    class MatrixArray<T> : IArray<T>
    {
        private IArray<IArray<T>> array;
        private int capacity;
        private int size;
        public MatrixArray()
        {
            this.capacity = 10;
            array = new FactorArray<IArray<T>>(capacity);            
        }

        public MatrixArray(int capacity)
        {
            array = new FactorArray<IArray<T>>(capacity);
            this.capacity = capacity;
        }

        public void Add(T item)
        {            
            if (Size() == array.Size() * capacity)
            {
                array.Add(new VectorArray<T>(capacity));
            }
            array.Get(array.Size() - 1).Add(item);
            size++;
        }

        public void Add(T item, int index)
        {
            if (Size() == array.Size() * capacity)
            {
                array.Add(new VectorArray<T>(capacity));
            }

            for(int i = array.Size() - 1; i > (index / capacity); i--)
            {
                IArray<T> row = array.Get(i);
                IArray<T> prevRow = array.Get(i - 1);
                row.Add(prevRow.Get(prevRow.Size() - 1),0);
                prevRow.Remove(prevRow.Size() - 1);
            }
            array.Get(index / capacity).Add(item, index % capacity);
            size++;
        }

        public T Get(int index)
        {            
            return array.Get(index / capacity).Get(index % capacity);
        }

        public T Remove(int index)
        {
            T result = Get(index);
            size--;
            array.Get(index / capacity).Remove(index % capacity);
            for (int i = (index / capacity) + 1; i < array.Size(); i++)
            {
                IArray<T> row = array.Get(i);
                IArray<T> prevRow = array.Get(i - 1);
                prevRow.Add(row.Get(0));
                row.Remove(0);
            }
            return result;
        }

        public int Size()
        {
            return size;
        }
    }  
}
