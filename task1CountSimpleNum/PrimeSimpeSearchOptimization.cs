using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeSimpeSearchOptimization : Task
    {
        private List<int> primes;

        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            primes = new List<int>();
            for(int i = 2; i <= num; i++)
            {
                if (Calc(i))
                {
                    primes.Add(i);
                }
            }
            return primes.Count.ToString();
        }

        private bool Calc(int num)
        {
            if (num == 2)
                return true;
            for (int i = 0; primes[i] * primes[i] <= num; i++)
            {
                if (num % primes[i] == 0)
                    return false;
            }
            return true;
        }
    }
}
