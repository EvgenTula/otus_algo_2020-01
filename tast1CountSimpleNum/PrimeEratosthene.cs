using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeEratosthene : Task
    {
        public override string Run(string[] data)
        {
            List<int> primes = new List<int>();
            int num = int.Parse(data[0]);
            for (int i = 2; i <= num; i++)
            {
                if (Calc(i))
                {
                    primes.Add(i);
                }
            }
            return primes.Count.ToString();
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
