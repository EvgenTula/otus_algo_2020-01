using SimpleTester;
using System;

namespace task1Fibonacci
{
    class Recursive : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            return Calc(num - 1).ToString();
        }

        private int Calc(int num)
        {
            if (num < 2)
                return 1;
            else
                return Calc(num - 1) + Calc(num - 2);
        }
    }
}
