using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class PaintHouseI
    {
        public int MinCost(int[][] costs)
        {
            int n = costs.Length;
            int[,] dp = new int[n, 3];

            dp[0, 0] = costs[0][0];
            dp[0, 1] = costs[0][1];
            dp[0, 2] = costs[0][2];

            for (int i = 1; i < n; i++)           //i: house # i 
            {
                for (int j = 0; j < 3; j++)      // j : color of house # i
                {
                    dp[i, j] = (int)1e9;
                    for (int k = 0; k < 3; k++)  // k: color of house # i - 1
                    {
                        if (j == k) continue;
                        dp[i, j] = Math.Min(dp[i, j]
                        , dp[i - 1, k] + costs[i][j]);
                    }
                }
            }

            int min = (int)1e9;
            for (int j = 0; j < 3; j++) min = Math.Min(min, dp[n - 1, j]);
            return min;
        }
    }
}
