using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeSimpeSearchOptimization : Task
    {
        private List<int> primes = new List<int>();

        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            for(int i = 2; i <= num; i++)
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
            if (num == 2)
                return true;
            for (int i = 0; primes[i] * primes[i] <= num; i+=2)
            {
                if (num % primes[i] == 0)
                    return false;
            }
            return true;
        }
    }
}
