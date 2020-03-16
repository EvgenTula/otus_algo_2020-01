using SimpleTester;

namespace task2King
{
    class King : Task
    {
        public override string Run(string[] data)
        {

            int x = int.Parse(data[0]);
            ulong k = 1ul << x;
            ulong nA = 0xFEFEFEFEFEFEFEFE;
            ulong nH = 0x7F7F7F7F7F7F7F7F;
            ulong mask =
                        ((k & nH) << 1) | ((k & nA) >> 1) |
                        ((k & nA) << 7) | ((k & nH) >> 7) |
                        (k << 8) | (k >> 8) |
                        ((k & nH) << 9) | ((k & nA) >> 9);
            long cnt = 0;
            while (mask > 0)
            {
                cnt++;
                mask &= mask - 1;
            }

            return cnt + "\r\n" + mask;
        }
    }
}
