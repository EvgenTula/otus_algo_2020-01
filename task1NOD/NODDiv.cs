using SimpleTester;

namespace task1NOD
{
    class NODDiv : ITask
    {
        public string Run(string[] data)
        {
            return Div(int.Parse(data[0]), int.Parse(data[1])).ToString();
        }

        private int Div(int a, int b)
        {
            if (b == 0)
                return a;
            return Div(b, a % b);
        }

    }
}
