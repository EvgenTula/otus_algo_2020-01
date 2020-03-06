using SimpleTester;

namespace task1POW
{
    class POWFullMultiplication : Task
    {
        public override string Run(string[] data)
        {
            return decimal.ToDouble(Calc(decimal.Parse(data[0]), decimal.Parse(data[1]))).ToString();
        }

        private decimal Calc(decimal num, decimal pow)
        {
            decimal result = 1;
            for(decimal i = 0; i < pow; i++)
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
