using SimpleTester;

namespace task1POW
{
    class POWDecomposition : ITask
    {
        public string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long num, long pow)
        {
            long result = 1;
            while(pow > 1)
            {
                if (pow % 2 == 1)
                {
                    result*=num;
                }
                num *= num;
                pow /= 2;
            }
            if (pow > 0) result *= num;
            return result;
        }
    }
}
