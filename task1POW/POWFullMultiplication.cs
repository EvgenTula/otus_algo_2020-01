using SimpleTester;
using System;

namespace task1POW
{
    class POWFullMultiplication : ITask
    {
        public string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long num, long pow)
        {
            long result = 1;
            for(long i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }
    }
}
