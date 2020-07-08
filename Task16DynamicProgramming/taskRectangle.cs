using System;
using System.Collections.Generic;
using System.Text;

namespace Task16DynamicProgramming
{
    public static class taskRectangle
    {
        private static int N;
        private static int M;
        private static int[,] map;
        private static int maxSquare;
        public static string Solution(List<string> args)
        {
            string[] param = args[0].Split(' ');
            N = int.Parse(param[0]);
            M = int.Parse(param[1]);
            map = new int[N, M];
            
            for(int j = 0; j < M; j++)
            {
                string[] line = args[j+1].Split(' ');
                for(int i = 0; i < N; i++)
                {
                    map[i, j] = int.Parse(line[i]);
                }
            }


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int tmpSquare = findMaxSquare(i, j);
                    if (maxSquare < tmpSquare)
                    {
                        maxSquare = tmpSquare;
                    }
                }
            }
            return maxSquare.ToString();
        }

        private static int findMaxSquare(int n, int m)
        {
            int lenM = 1;
            int limitLen = findWayLen(n, m);
            int localMaxSquare = lenM * limitLen;
            
            for (int indexM = m + 1; indexM < M; indexM++)
            {
                lenM++;
                int lenN = findWayLen(n, indexM);
                if (limitLen > lenN)
                {
                    limitLen = lenN;
                }
                if (lenN > limitLen)
                {
                    lenN = limitLen;
                }
                if (localMaxSquare < lenM * lenN)
                {
                    localMaxSquare = lenM * lenN;
                }
            }
            return localMaxSquare;
        }

        private static int findWayLen(int n, int m)
        {
            int result = 0;
            while (n < N)
            {
                if (map[n, m] == 1)
                    break;
                result++;
                n++;
            }
            return result;
        }
    }
}

