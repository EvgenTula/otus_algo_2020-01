using SimpleTester;

namespace task1NOD
{
    class NODSubtract : ITask
    {
        public string Run(string[] data)
        {
            return Subtract(int.Parse(data[0]), int.Parse(data[1])).ToString();
        }

        private int Subtract(int a, int b)
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
