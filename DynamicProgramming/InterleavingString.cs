using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;
            int n3 = s3.Length;

            bool[,,] dp = new bool[n3 + 1, n1 + 1, n2 + 1];
            dp[0, 0, 0] = true;

            for (int i = 1; i <= n3; i++)
                for (int j = 0; j <= n1; j++)
                    for (int k = 0; k <= n2; k++)
                    {
                        if (k > 0) dp[i, j, k - 1] = dp[i, j, k - 1]
                                       || (getChar(s3, i) == getChar(s1, j) && j > 0 && dp[i - 1, j - 1, k - 1]);

                        if (j > 0) dp[i, j - 1, k] = dp[i, j - 1, k]
                                       || (getChar(s3, i) == getChar(s2, k) && k > 0 && dp[i - 1, j - 1, k - 1]);

                        dp[i, j, k] = dp[i, j, k]
                                       || (getChar(s3, i) == getChar(s2, k) && k > 0 && dp[i - 1, j, k - 1])
                                       || (getChar(s3, i) == getChar(s1, j) && j > 0 && dp[i - 1, j - 1, k]);
                    }

            return dp[n3, n1, n2];
        }

        private char getChar(string s, int i)
        {
            if (i == 0) return (char)' ';
            return s[i - 1];
        }
    }
}
