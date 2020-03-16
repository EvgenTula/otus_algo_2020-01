using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeEratostheneOptimization : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            byte[] primes = new byte[num];
            int current_item = 2;

            while (current_item * current_item < primes.Length)
            {
                int step = 2;

                for (int i = current_item * current_item; i < primes.Length; i = current_item * step)
                {
                    primes[i] = 1;
                    step++;
                }
                while (primes[++current_item] == 1) { };
            }

            int countPrimes = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == 0)
                    countPrimes++;
            }

            return countPrimes.ToString();
        }  
    }
}
