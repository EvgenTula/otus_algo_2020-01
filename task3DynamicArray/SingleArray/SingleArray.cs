using System;
using System.Collections;
using System.Collections.Generic;

namespace task3DynamicArray
{
    public class SingleArray<T> : IArray<T>, IEnumerable<T>
    {
        private T[] array;
        public SingleArray()
        {
            array = new T[0];
        }

        public void Add(T item)
        {
            Add(item, Size());
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

        public void Set(int index, T value)
        {
            array[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleArrayEnum<T>(this);
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

        public T this[int index]
        { 
            get
            {
                return Get(index);
            }
            set
            {
                Set(index, value);
            }
        }       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SingleArrayEnum<T> : IEnumerator<T>
    {
        int position = -1;
        SingleArray<T> array;
        public SingleArrayEnum(SingleArray<T> singeArray)
        {
            array = singeArray;
        }

        T IEnumerator<T>.Current
        { 
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }


        object IEnumerator.Current
        { 
            get
            {
                return ((IEnumerator<T>)this).Current;
            }
        }


        public void Dispose()
        {
            array = null;
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Size());
        }

        public void Reset()
        {
            position = -1;
        }
    }

}
