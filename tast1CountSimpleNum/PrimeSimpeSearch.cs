using SimpleTester;
using System;

namespace tast1Prime
{
    class PrimeSimpeSearch : Task
    {
        public object Conole { get; private set; }

        public override string Run(string[] data)
        {
            return Calc(long.Parse(data[0])).ToString();
        }

        private bool Calc(long num)
        {
            int count = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    count++;
            }
            return count == 2;
        }
    }
}
