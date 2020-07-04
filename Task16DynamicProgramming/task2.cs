using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Task16DynamicProgramming
{
    public static class task2
    {
        public static string Solution(List<String> data)
        {
            int n = int.Parse(data[0]);
            int[,] m = new int[100, 100];
            for(int i = 0; i < n; i++)
            {
                string[] nums = data[i+1].Split(' ');
                for(int j = 0; j < nums.Length; j++)
                {
                    m[i, j] = int.Parse(nums[j]);
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    m[i, j] += Math.Max(m[i+1,j], m[i+1,j+1]);
                }
            }

            return m[0, 0].ToString();
        }
    }
}
