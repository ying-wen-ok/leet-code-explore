using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    internal class BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[] maxFuturePriceFromNow = new int[n + 1]; //  include bundrary

            int maxFuturePrice = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                maxFuturePrice = Math.Max(maxFuturePrice, prices[i]);
                maxFuturePriceFromNow[i] = maxFuturePrice;
            }

            int maxP = 0;
            for (int i = 0; i < n; i++)
            {
                maxP = Math.Max(maxP, maxFuturePriceFromNow[i + 1] - prices[i]);
            }
            return maxP;
        }
    }
}
