using SimpleTester;
using System;
using System.Text;

namespace task3DynamicArray
{
    class SingleArrayTask : Task
    {
        public override string Run(string[] data)
        {
            int count = int.Parse(data[0]);
            StringBuilder stringBulder = new StringBuilder();
            SingleArray<String> array = new SingleArray<string>();
            for (int i = 0; i < count; i++)
            {
                array.Add(i + "");
                stringBulder.Append(i + " ");
            }
            return stringBulder.ToString().TrimEnd();
        }
    }
}
