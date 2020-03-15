using SimpleTester;

namespace task1NOD
{
    class NODDiv : Task
    {
        public override string Run(string[] data)
        {
            return Calc(long.Parse(data[0]), long.Parse(data[1])).ToString();
        }

        private long Calc(long a, long b)
        {
            if (b == 0)
                return a;
            return Calc(b, a % b);
        }

    }
}
