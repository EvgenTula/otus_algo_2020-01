using SimpleTester;

namespace task1POW
{
    class POWPartialMultiplication : Task
    {
        public override string Run(string[] data)
        {
            return decimal.ToDouble(Calc(decimal.Parse(data[0]), int.Parse(data[1]))).ToString();
        }

        private decimal Calc(decimal num, int pow)
        {
            decimal result = num;
            decimal count = 1;
            
            while((count *= 2) < pow)
            {
                result *= result;
            }
            count /= 2;
            for (decimal i = 0; i < (pow - count); i++)
            {
                result *= num;
            }

            return result;
        }

        public override string ParseExpect(string data)
        {
            return decimal.ToDouble(decimal.Parse(data)).ToString();
        }
    }
}
