using System;

namespace task3DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleArray<String> singleArray = new SingleArray<string>();
            addValues(singleArray, 10);
            singleArray.Add("ЫЫЫ", 3);
            singleArray.Remove(3);
            Console.ReadKey();
        }

        static void addValues(IArray<String> array, int count)
        {
            for(int i = 0; i < count; i++)
            {
                array.Add(i + "");
            }
        }

        static void getValues(IArray<String> array, int count)
        {

        }
    }
}
