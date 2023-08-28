using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class BestTimeToBuyandSellStockWithTransactionFee
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int n = prices.Length;
            int[,] dp = new int[n + 1, 2];
            dp[0, 0] = 0;
            dp[0, 1] = -(int)1e9;
         
            for (int i = 1; i <= n; i++)
            {
                int todayPrice = prices[i - 1];

                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + todayPrice - fee);
                dp[i, 1] = Math.Max(dp[i - 1, 0] - todayPrice, dp[i - 1, 1]);
            }

            return Math.Max(dp[n, 0], dp[n, 1]);
        }
    }
}
