using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeEratostheneN : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            List<int> primes = new List<int>();
            int[] numbers = new int[num];

            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = i;
                    primes.Add(i);
                }
                
                foreach(var item in primes)
                {
                    if (item * i >= numbers.Length)
                    {
                        break;
                    }
                    if (item <= numbers[i])
                    {
                        numbers[item * i] = item;
                    }
                }                
            }
            return primes.Count.ToString();
        }
    }
}
