using SimpleTester;
using System.Collections.Generic;

namespace tast1Prime
{
    class PrimeEratostheneOptimization : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            List<int> primes = new List<int>(num);
            for (int i = 2; i <= num; i++)
            {
                primes.Add(i);
            }
   
            int curret_num = 2;
            int index = primes.IndexOf(curret_num);

            while (curret_num * curret_num <= num)
            {
                int step = 2;
                
                for (int i = curret_num * curret_num; i <= num; i = curret_num * step)
                {
                    primes.Remove(i);
                    step++;
                }
                index++;
                curret_num = primes[index];
            }    
            return primes.Count.ToString();
        }  
    }
}
