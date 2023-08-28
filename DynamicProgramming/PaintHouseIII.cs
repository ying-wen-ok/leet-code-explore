using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class PaintHouseIII
    {
        public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {

            int[,,] dp = new int[m, n + 1, target + 1];
            for (int i = 0; i < m; i++)
                for (int j = 0; j <= n; j++)
                    for (int k = 0; k <= target; k++)
                        dp[i, j, k] = (int)1e9;

            if (houses[0] > 0)
            {
                dp[0, houses[0], 1] = 0;
            }
            else
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[0, j, 1] = cost[0][j - 1];
                }
            }

            for (int i = 1; i < m; i++)                  // house Id
            {
                for (int j = 1; j <= n; j++)             // color of houses[i]
                {
                    for (int prej = 1; prej <= n; prej++) // color of houses[i - 1]
                    {
                        for (int prek = 1; prek <= target && prek <= i; prek++) // count of the previous neighborhoods
                        {
                            int k = (j == prej) ? prek : prek + 1;
                            if (k > target || k > i + 1) continue;
                            if (houses[i] == 0) dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, prej, prek] + cost[i][j - 1]);
                            else if (houses[i] == j) dp[i, j, k] = Math.Min(dp[i, j, k], dp[i - 1, prej, prek]);
                        }
                    }
                }
            }

            int min = (int)1e9;
            for (int x = 1; x <= n; x++) min = Math.Min(min, dp[m - 1, x, target]);
            return min == (int)1e9 ? -1 : min;
        }
    }
}
