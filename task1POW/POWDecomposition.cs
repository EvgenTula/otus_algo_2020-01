using SimpleTester;

namespace task1POW
{
    class POWDecomposition : Task
    {
        public override string Run(string[] data)
        {
            return decimal.ToDouble(Calc(decimal.Parse(data[0]), int.Parse(data[1]))).ToString();
        }

        private decimal Calc(decimal num, int pow)
        {
            decimal result = 1;
            while (pow > 1)
            {
                if (pow % 2 == 1)
                    result *= num;
                num *= num;
                pow /= 2;
            }
            
            if (pow > 0)
                result *= num;

            return result;
        }

        public override string ParseExpect(string data)
        {
            return decimal.ToDouble(decimal.Parse(data)).ToString();
        }
    }
}
