using SimpleTester;

namespace task1NOD
{
    class NODSubtract : Task
    {
        public override string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

    }
}
