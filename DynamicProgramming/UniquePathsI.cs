using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    internal class UniquePathsI
    {
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++) dp[i, 0] = 1;
            for (int i = 0; i < n; i++) dp[0, i] = 1;

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }

            return dp[m - 1, n - 1];
        }
        // DP solution
        // time complexcity : big O(m * n)  -> O(10^4)
        // space complectiy : big O(m * n)  -> O(10^4)

        // recursion without memorization solution
        // time complexcity : 2 to the max(m, n)th power -> O(2^100) = 1,267,650,600,228,229,401,496,703,205,376 
        // space complectiy : 2 to the max(m, n)th power -> O(2^100)
    }
}
