using System;

namespace task3DynamicArray
{
    interface IArray<T>
    {
        int Size();
        void Add(T item);
        void Add(T item, int index);
        T Get(int index);
        T Remove(int index);
        T[] Resize(T[] array, int delta)
        {
            T[] result = new T[array.Length + delta];
            Array.Copy(array, result, array.Length);
            return result;
        }
    }
}
