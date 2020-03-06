using SimpleTester;

namespace task1NOD
{
    class NODDiv : ITask
    {
        public string Run(string[] data)
        {
            return Calc(int.Parse(data[0]), int.Parse(data[1])).ToString();
        }

        private int Calc(int a, int b)
        {
            if (b == 0)
                return a;
            return Calc(b, a % b);
        }

    }
}
