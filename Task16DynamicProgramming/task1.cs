using System;
using System.Collections.Generic;
using System.Text;

namespace Task16DynamicProgramming
{
    public static class task1
    {
        public static string Solution(string args)
        {
            string[] line = args.Split('+', '/');
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);
            int d = int.Parse(line[3]);

            int x = a * d + b * c;
            int y = b * d;

            int gcd = GCD(x, y);
            x /= gcd;
            y /= gcd;
            return (x + "/" + y);
        }

        private static int GCD(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (even(a) && even(b))
                return 2 * GCD(a >> 1, b >> 1);

            if (even(a) && odd(b))
                return GCD(a >> 1, b);

            if (odd(a) && even(b))
                return GCD(a, b >> 1);

            if (a > b)
                return GCD((a - b) >> 1, b);
            else
                return GCD(a, (b - a) >> 1);
        }

        private static bool even(int num)
        {
            return (num & 1) == 0;
        }

        private static bool odd(int num)
        {
            return (num & 1) == 1;
        }
    }
}
