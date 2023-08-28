using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class LongestCommonSubsequenceLength
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int n1 = text1.Length;
            int n2 = text2.Length;

            int[,] f = new int[n1 + 1, n2 + 1];
            for (int i = 1; i <= n1; i++)
                for (int j = 1; j <= n2; j++)
                {
                    f[i, j] = Math.Max
                    (
                        f[i - 1, j - 1] + ((text1[i - 1] == text2[j - 1]) ? 1 : 0),
                        Math.Max(f[i, j - 1], f[i - 1, j])
                    );
                }
            return f[n1, n2];
        }
    }
}
