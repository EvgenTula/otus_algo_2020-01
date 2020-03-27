using System;
using System.Collections.Generic;
using System.Text;

namespace task3DynamicArray
{
    class SingleArray<T> : IArray<T>
    {
        private T[] array;
        public SingleArray()
        {
            array = new T[0];
        }

        public void Add(T item)
        {
            array = ((IArray<T>)this).Resize(array, 1);
            array[Size() - 1] = item;
        }

        public void Add(T item, int index)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            return array[index];
        }

        public T Remove(int index)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            return array.Length;
        }
    }
}
