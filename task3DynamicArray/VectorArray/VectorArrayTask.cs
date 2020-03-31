using SimpleTester;
using System;
using System.Text;

namespace task3DynamicArray
{
    class VectorArrayTask : Task
    {
        public override string Run(string[] data)
        {
            int count = int.Parse(data[0]);
            StringBuilder stringBulder = new StringBuilder();
            VectorArray<String> array = new VectorArray<string>();
            for (int i = 0; i < count; i++)
            {
                array.Add(i + "");
                stringBulder.Append(i + " ");
            }
            return stringBulder.ToString().TrimEnd();
        }
    }
}
