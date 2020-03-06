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

            //int num = int.Parse(data[0]);
            /*
            int cnt = 0;
            for (int i = 0; i <= 1000; i++)
            {
                if (Calc(i))
                {
                    cnt++;
                }
            }

            Console.WriteLine(cnt);
            return cnt.ToString();
            */
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
