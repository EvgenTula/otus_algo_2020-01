using SimpleTester;

namespace task1NOD
{
    class NODShift : ITask
    {
        public string Run(string[] data)
        {
            return Shift(int.Parse(data[0]), int.Parse(data[1])).ToString();
        }

        private int Shift(int a, int b)
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
                return 2 * Shift(a >> 1, b >> 1);
            }

            if ((a & 1) == 0 && (b & 1) != 0)
            {
                return Shift(a >> 1, b);
            }

            if ((a & 1) != 0 && (b & 1) == 0)
            {
                return Shift(a, b >> 1);
            }

            if (a < b)
            {
                return Shift((b - a) >> 1, a);
            }
            else
            {
                return Shift((a - b) >> 1, b);
            }
        }

    }
}
