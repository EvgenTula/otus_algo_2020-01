﻿using System;

namespace task3DynamicArray
{
    class FactorArray<T> : IArray<T>
    {
        private T[] array;
        private int capacity;
        private int size;
        public FactorArray()
        {
            this.capacity = 100;
            array = new T[this.capacity];            
        }

        public FactorArray(int capacity)
        {
            this.capacity = capacity;
            array = new T[this.capacity];
        }

        public void Add(T item)
        {
            Add(item, Size());          
        }

        public void Add(T item, int index)
        {

            T[] newArray = null;
            if (Size() == array.Length)
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
