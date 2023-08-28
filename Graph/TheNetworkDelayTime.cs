using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class TheNetworkDelayTime
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int infinity = (int)1e9;
            int[,] dp = new int[n + 1, n];
            for (int i = 0; i <= n; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = infinity;

            for (int j = 0; j < n; j++) dp[k, j] = 0;

            for (int j = 0; j < n - 1; j++)
            {
                foreach (int[] edge in times)
                {
                    int from = edge[0];
                    int to = edge[1];
                    int weight = edge[2];

                    dp[to, j + 1] = Math.Min(dp[to, j + 1], dp[from, j] + weight);
                }
            }

            int max = -1;
            for (int i = 1; i <= n; i++) max = Math.Max(max, dp[i, n - 1]);
            return (max == infinity) ? -1 : max;
        }
    }
}
