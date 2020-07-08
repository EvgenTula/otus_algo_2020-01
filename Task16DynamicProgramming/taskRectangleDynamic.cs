using System;
using System.Collections.Generic;

namespace Task16DynamicProgramming
{
    public static class taskRectangleDynamic
    {
        private static int N;
        private static int M;
        private static int T;
        private static HashSet<Coord> map;
        
        public static string Solution(List<string> args)
        {
            string[] param = args[0].Split(' ');
            N = int.Parse(param[0]); //width
            M = int.Parse(param[1]); //length
            T = int.Parse(args[1]);
            map = new HashSet<Coord>();
            for (int i = 0; i < T; i++)
            {
                string[] line = args[i+2].Split(' ');
                int x = int.Parse(line[0]);
                int y = int.Parse(line[1]);
                Coord obj = new Coord(x, y);
                map.Add(obj);
            }

            int result = Calculate();
            return result.ToString();
        }

        private static int Calculate()
        {
            int maxSquare = -1;
            int[] rowLenghts = new int[N];
            for (int m = 0; m < M; m++)
            {
                CalcRow(m, ref rowLenghts);
                int[] leftLimit = GetLeft(rowLenghts);
                int[] rightLimit = GetRight(rowLenghts);
                int localMax = GetMaxRowSquare(leftLimit, rightLimit, rowLenghts);
                if (maxSquare < localMax)
                    maxSquare = localMax;
            }
            return maxSquare;
        }

        private static void CalcRow(int m, ref int[] rowLenghts)
        {
            for(int n = 0; n < N; n++)
            {
                Coord obj = new Coord(n, m);
                if (map.Contains(obj))
                    rowLenghts[n] = 0;
                else
                    rowLenghts[n]++;
            }
        }

        private static int[] GetRight(int[] rowLenghts)
        {
            int[] result = new int[N];
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < N; i++)
            {
                while (stack.Count > 0)
                {
                    if (rowLenghts[i] < rowLenghts[stack.Peek()])
                    {
                        result[stack.Pop()] = i - 1;
                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push(i);
            }
            while(stack.Count>0)
            {
                result[stack.Pop()] = N - 1;
            }
            return result;
        }

        private static int[] GetLeft(int[] rowLenghts)
        {
            int[] result = new int[N];
            Stack<int> stack = new Stack<int>();
            for (int i = N-1; i >= 0; i--)
            {
                while (stack.Count > 0)
                {
                    if (rowLenghts[i] < rowLenghts[stack.Peek()])
                    {
                        result[stack.Pop()] = i + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                result[stack.Pop()] = 0;
            }
            return result;
        }

        private static int GetMaxRowSquare(int[] left, int[] right, int[] rowLenghts)
        {
            int max = -1;
            for(int n = 0; n < N; n++)
            {
                int s = (right[n] - left[n] + 1) * rowLenghts[n];
                if (s > max)
                    max = s;
            }
            return max;
        }

        struct Coord
        {
            public int x;
            public int y;
            public Coord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
