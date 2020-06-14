using System;

namespace Task8SegmentTree
{
    class Program
    {
        int[] arr;
        int size;
        int count_query;
        static void Main(string[] args)
        {
            Program program = new Program();
            
            /*
            program.size = 5;
            program.count_query = 9;
            program.TreeBuilder(program.size);
            program.SetItem(1, 5);
            program.SetItem(2, 2);
            program.SetItem(3, 1);
            program.SetItem(4, 2);
            program.SetItem(5, 10);

            Console.WriteLine(program.GetSum(1, 1));
            Console.WriteLine(program.GetSum(2, 2));
            Console.WriteLine(program.GetSum(3, 3));
            Console.WriteLine(program.GetSum(4, 4));
            Console.WriteLine(program.GetSum(5, 5));
            Console.WriteLine(program.GetSum(1, 5));
            Console.WriteLine(program.GetSum(1, 2));
            Console.WriteLine(program.GetSum(1, 4));
            Console.WriteLine(program.GetSum(2, 3));
            Console.WriteLine(program.GetSum(2, 4));
            Console.WriteLine(program.GetSum(3, 4));
            Console.WriteLine(program.GetSum(4, 5));
            Console.WriteLine(program.GetSum(3, 5));
            */
            
            string[] param = Console.ReadLine().Split(' ');
            program.size = int.Parse(param[0]);
            program.count_query = int.Parse(param[1]);
            program.TreeBuilder(program.size);
            int i = 0;
            while (i < program.count_query)
            {
                string[] query_param = Console.ReadLine().Split(' ');
                if (query_param[0] == "A")
                    program.SetItem(int.Parse(query_param[1]), int.Parse(query_param[2]));
                else
                    //results[i] = program.GetSum(int.Parse(query_param[1]), int.Parse(query_param[2]));
                    Console.WriteLine(program.GetSum(int.Parse(query_param[1]), int.Parse(query_param[2])));
                i++;
            }
            Console.ReadKey();
        }

        private void TreeBuilder(int size)
        {
            int n = (1 << (int)(Math.Log(size - 1,2) + 1));
            arr = new int[n * 2];          
        }

        public void SetItem(int index, int val)
        {
            index = (this.arr.Length / 2) + index - 1;
            arr[index] = val;
            while (index > 0)
            {
                if (index % 2 != 0)
                    index = (index - 1) / 2;
                else
                    index = index / 2;
                arr[index] = arr[2 * index] + arr[index * 2 + 1];
            }
        }

        public int GetSum(int left, int right)
        {
            int result = 0;
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
    }
}
