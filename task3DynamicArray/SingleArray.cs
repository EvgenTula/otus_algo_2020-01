using System;

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
            Add(item, Size());
            /*
            array = ((IArray<T>)this).Resize(array, 1);
            array[Size() - 1] = item;
            */
        }

        public void Add(T item, int index)
        {
            T[] newArray = new T[Size() + 1];
            Array.Copy(array, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(array, index, newArray, index + 1, array.Length - index);
            array = newArray;
        }

        public T Get(int index)
        {
            return array[index];
        }

        public T Remove(int index)
        {
            T result = Get(index);

            T[] newArray = new T[Size() - 1];
            Array.Copy(array, index + 1, newArray, index, array.Length - (index + 1));
            array = newArray;
            return result;
        }

        public int Size()
        {
            return array.Length;
        }
    }
}
