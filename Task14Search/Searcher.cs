using System;
using System.Runtime.InteropServices.ComTypes;

namespace Task14Search
{
    class Searcher
    {

        #region Алгоритм Бойера-Мура
        public int BM(string text, string pattern)
        {
            int[] prefixTable = CreatePrefix(pattern);
            int[] suffixTable = CreateSuffix(pattern);
            int last = pattern.Length - 1;
            int t = 0;
            while(t < text.Length - last)
            {
                int p = last;
                while(p >= 0 && text[t+p] == pattern[p])
                {
                    p--;
                }
                if (p == -1)
                    return t;
                t += Math.Max(p - prefixTable[text[t + p]], suffixTable[p + 1]);
            }
            return -1;
        }

        private int[] CreatePrefix(string pattern)
        {
            int[] prefix = new int[128];
            for (int i = 0; i < prefix.Length; i++)
            {
                prefix[i] = -1;
            }
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                prefix[pattern[i]] = i;
            }
            return prefix;
        }

        public int[] CreateSuffix(string pattern)
        {
            int[] suffix = new int[pattern.Length + 1];
            for(int i = 0; i < suffix.Length; i++)
            {
                suffix[i] = pattern.Length;
            }
            suffix[pattern.Length] = 1;
            for(int j = pattern.Length - 1; j >= 0; j--)
            {
                for(int at = j; at < pattern.Length; at++)
                {
                    string a = pattern.Substring(at);
                    for(int i = at - 1; i >= 0; i--)
                    {
                        string b = pattern.Substring(i, a.Length);
                        if (a == b)
                        {
                            suffix[j] = at - 1;
                            at = pattern.Length;
                            break;
                        }
                    }
                }
            }
            return suffix;
        }

        #endregion;


        #region KMP

        #region test
        private class Automat
        { 
            public static int[,] Create(string pattern)
            {
                int[,] result = new int[pattern.Length, 4];
                for (int i = 0; i < pattern.Length; i++)
                {
                    for (char a = 'A'; a <= 'D'; a++)
                    {
                        string state = pattern.Left(i) + a;
                        int k = i + 1;
                        while (pattern.Left(k) != state.Right(k))
                        {
                            k--;
                        }
                        result[i, a - 'A'] = k;
                        
                    }
                }
                return result;
            }
        }
        
        private int TmpKMP(string text, string pattern)
        {
            int[,] automat = Automat.Create(pattern);
            int q = 0;
            for (int i = 0; i < text.Length; i++)
            {
                q = automat[q, text[i] - 'A'];
                if (q == pattern.Length)
                    return i - pattern.Length + 1;
            }
            return -1;
        }

        private int[] ComputePiSlow(string pattern)
        {
            int n = pattern.Length;
            int[] pi = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int q = 0; q <= i; q++)
                {
                    if (pattern.Left(q) == pattern.Left(i + 1).Right(q))
                        pi[i] = q;
                }
            }
            return pi;
        }

        #endregion


        public int KMP(string text, string pattern)
        {
            var pi = ComputePiFast(pattern);

            int n = text.Length;
            int q = 0;
            for (int i = 0; i < n; i++)
            {
                while (q > 0 && text[i] != pattern[q])
                {
                    q = pi[q - 1];
                }
                if (text[i] == pattern[q])
                    q++;
                if (q == pattern.Length)
                    return i - pattern.Length + 1;
            }
            return -1;
        }



     
        private int[] ComputePiFast(string pattern)
        {
            int n = pattern.Length;
            int[] pi = new int[n];
            pi[0] = 0;
            for (int i = 1; i < n; i++)
            {
                int q = pi[i - 1];
                while(q > 0 && pattern[i] != pattern[q])
                {
                    q = pi[q - 1];
                }
                if (pattern[i] == pattern[q])
                    q++;
                pi[i] = q;
            }
            return pi;
        }


        #endregion
    }

    static class Helper
    { 
        public static string Left(this string text, int a)
        {
            return text.Substring(0, a);
        }

        public static string Right(this string text, int a)
        {
            return text.Substring(text.Length - a, a);
        }
    }
 
}
