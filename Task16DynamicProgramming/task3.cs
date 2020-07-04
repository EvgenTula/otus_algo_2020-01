using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Task16DynamicProgramming
{
    public static class task3
    {
        public static string Solution(string args)
        {
            int n = int.Parse(args);
            Int64 a = 1;
            Int64 c = 0;
            for(int i = 2; i <= n; i++)
            {
                var a1 = a + c;
                var c1 = a;
                a = a1;
                c = c1;
            }
            return (a + a + c + c).ToString();
        }
    }
}
