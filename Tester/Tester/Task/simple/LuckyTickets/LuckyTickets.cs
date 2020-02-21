using System;

namespace Tester
{
    class LuckyTickets : ITask
    {
        int n;
        int qty;

        public string Run(string[] data)
        {
            n = Convert.ToInt32(data[0]);
            qty = 0;
            NextDigit(0, 0, 0);
            return qty.ToString();
        }

        public int Tickets6()
        {
            int count = 0;
            for (int a1 = 0; a1 <= 9; a1++)
            for (int a2 = 0; a2 <= 9; a2++)
            for (int a3 = 0; a3 <= 9; a3++)
            { 
                int a6 = a1 + a2 - a3;
                if (a6 >= 0 && a6 <= 9)
                    count ++;
            }
            return count;
        }

        public void NextDigit(int nr, int sum1, int sum2)
        {
            if (nr == 2 * n)
            {
                if (sum1 == sum2)
                    qty++;
                return;
            }
            for (int a = 0; a <= 9; a ++)
                if (nr < n)
                    NextDigit(nr + 1, sum1 + a, sum2);
                else
                    NextDigit(nr + 1, sum1, sum2 + a);
        }
    }
}
