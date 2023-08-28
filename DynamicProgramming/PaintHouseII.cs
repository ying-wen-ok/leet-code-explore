using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class PaintHouseII
    {
        public int MinCostII(int[][] costs)
        {
            int n = costs.Length;
            int k = costs[0].Length;

            int[,] dp = new int[n, k];

            for (int i = 0; i < k; i++)
            {
                dp[0, i] = costs[0][i];
            }

            for (int i = 1; i < n; i++)           //i: house # i 
            {
                for (int j = 0; j < k; j++)      // j : color of house # i
                {
                    dp[i, j] = (int)1e9;
                    for (int x = 0; x < k; x++)  // k: color of house # i - 1
                    {
                        if (j == x) continue;
                        dp[i, j] = Math.Min(dp[i, j]
                        , dp[i - 1, x] + costs[i][j]);
                    }
                }
            }

            int min = (int)1e9;
            for (int j = 0; j < k; j++) min = Math.Min(min, dp[n - 1, j]);
            return min;
        }
    }
}
