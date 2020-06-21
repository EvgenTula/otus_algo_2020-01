using System;
using System.IO;

namespace Task8SegmentTree
{
    class Program
    {
        long[] arr;
        int size;
        long count_query;
        static void Main(string[] args)
        {
            Program program = new Program();

            using (StreamReader reader = new StreamReader("sum.in"))
            {
                string[] param = reader.ReadLine().Split(' ');
                program.size = int.Parse(param[0]);
                program.count_query = int.Parse(param[1]);
                program.TreeBuilder(program.size);
                int i = 0;
                using (StreamWriter writer = new StreamWriter("sum.out"))
                {
                    while (i < program.count_query)
                    {
                        string[] query_param = reader.ReadLine().Split(' ');
                        if (query_param[0] == "A")
                        {
                            program.SetItem(int.Parse(query_param[1]), int.Parse(query_param[2]));
                        }
                        else
                        {
                            writer.WriteLine(program.GetSum(int.Parse(query_param[1]), int.Parse(query_param[2])));
                        }
                        i++;
                    }
                }
            }
           
            //Console.ReadKey();
        }

        private void TreeBuilder(int size)
        {
            int n = 1 << Log2(size - 1) + 1;
            arr = new long[n * 2];
        }

        public void SetItem(int index, int val)
        {
            index += (this.arr.Length / 2) - 1;
            arr[index] = val;
            do
            {
                index /= 2;
                arr[index] = arr[2 * index] + arr[index * 2 + 1];
            } while (index > 1);
        } 

        public long GetSum(int left, int right)
        {
            long result = 0;
            int n = arr.Length / 2;

            left += n - 1;
            right += n - 1;

            while (left <= right)
            {
                if (left % 2 != 0)
                    result += arr[left];

                if (right % 2 == 0)
                    result += arr[right];

                left = (left + 1) / 2;
                right = (right - 1) / 2;
            }
            return result;
        }

        private int Log2(int a)
        {
            return (int)Math.Log(a, 2);
        }
    }
}