using SimpleTester;
using System;
namespace task1Fibonacci
{
    class GoldenRatio : Task
    {
        public override string Run(string[] data)
        {           
            double num = double.Parse(data[0]);
            double result = Math.Pow((Math.Sqrt(5) + 1) / 2, num) / Math.Sqrt(5) + 0.5;
            return Math.Truncate(result).ToString();
        }
    }
}
