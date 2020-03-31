using System;

namespace task3DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //IArray<String> array = new SingleArray<string>();
            //IArray<String> array = new VectorArray<string>(10);
            //IArray<String> array = new FactorArray<string>();
            IArray<String> array = new MatrixArray<string>();
            addValues(array, 100);
            array.Add("ЫЫЫ", 3);
            array.Remove(3);
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
