using SimpleTester;

namespace task1NOD
{
    class NODShift : Task
    {
        public override string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long a, long b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
           
            if ((a & 1) == 0 && (b & 1) == 0)
            {
                return 2 * Calc(a >> 1, b >> 1);
            }

            if ((a & 1) == 0 && (b & 1) != 0)
            {
                return Calc(a >> 1, b);
            }

            if ((a & 1) != 0 && (b & 1) == 0)
            {
                return Calc(a, b >> 1);
            }

            if (a < b)
            {
                return Calc((b - a) >> 1, a);
            }
            else
            {
                return Calc((a - b) >> 1, b);
            }
        }

    }
}
