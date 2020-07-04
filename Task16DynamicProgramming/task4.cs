using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task16DynamicProgramming
{
    public static class task4
    {
        static int n;
        static int[,] map;
        public static string Solution(List<string> args)
        {
            n = int.Parse(args[0]);
            map = new int[n, n];
            int islands = 0;
            for(int y = 0; y < n; y++)
            {
                string[] nums = args[y+1].Split(' ');
                for(int x = 0; x < n; x++)
                {
                    map[x, y] = int.Parse(nums[x]);
                }
            }

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (map[x,y] == 1)
                    {
                        islands++;
                        go(x, y);
                    }
                }
            }
            
            return islands.ToString();
        }

        static void go(int x, int y)
        {
            if (x < 0 || x >= n) return;
            if (y < 0 || y >= n) return;
            if (map[x, y] == 0) return;
            map[x, y] = 0;
            go(x - 1, y);
            go(x + 1, y);
            go(x, y - 1);
            go(x, y + 1);
        }
    }
}
