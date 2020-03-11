using SimpleTester;

namespace task1Fibonacci
{
    class Iteration : Task
    {
        public override string Run(string[] data)
        {
            int num = int.Parse(data[0]);
            int a = 1;
            int b = 1;
            for (int i = 3; i <= num; i++)
            {
                int sum = a + b;
                a = b;
                b = sum;
            }
            return b.ToString();
        }
    }
}
