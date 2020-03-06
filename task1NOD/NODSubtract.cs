using SimpleTester;

namespace task1NOD
{
    class NODSubtract : Task
    {
        public override string Run(string[] data)
        {
            return Calc(int.Parse(data[0]), int.Parse(data[1])).ToString();
        }

        private int Calc(int a, int b)
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
