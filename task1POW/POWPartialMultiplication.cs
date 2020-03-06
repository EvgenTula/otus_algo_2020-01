using System;
using SimpleTester;

namespace task1POW
{
    class POWPartialMultiplication : ITask
    {
        public string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long num, long pow)
        {
            long result = num;
            long count = 1;
            
            while((count *= 2) < pow)
            {
                result *= result;
            }
            count /= 2;
            for (long i = 0; i < (pow - count); i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
