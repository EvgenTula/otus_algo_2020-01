using System;
using System.Collections.Generic;
using System.Text;

namespace task3DynamicArray
{
    class ArrayList<T> : IArray<T>
    {
        List<T> array;
        public ArrayList()
        {
            array = new List<T>();
        }
        public ArrayList(int capacity)
        {
            array = new List<T>(capacity);
        }
        public void Add(T item)
        {
            array.Add(item);
        }

        public void Add(T item, int index)
        {
            array.Insert(index, item);
        }

        public T Get(int index)
        {
            return array[index];
        }

        public T Remove(int index)
        {
            T tmp = array[index];
            array.RemoveAt(index);
            return tmp;
        }

        public int Size()
        {
            return array.Count;
        }
    }
}
