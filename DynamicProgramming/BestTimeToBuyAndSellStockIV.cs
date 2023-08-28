using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class BestTimeToBuyAndSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;
            int[,,] f = new int[n + 1, k + 1, 2];

            for (int i = n - 1; i >= 0; i--)  // i: # 'th day
                for (int j = 0; j <= k; j++) // j: # Transaction Opportunity Left
                    for (int holding = 0; holding <= 1; holding++) // bool value, 0: no holding; 1: holding 
                    {
                        int doNothing = f[i + 1, j, holding];
                        int doSomething = 0;
                        if (holding == 1 && j > 0)
                        {
                            // sell
                            doSomething = prices[i] + f[i + 1, j - 1, 0];
                        }
                        else if (holding == 0 && j > 0)
                        {
                            // buy
                            doSomething = -prices[i] + f[i + 1, j, 1];
                        }

                        f[i, j, holding] = Math.Max(doNothing, doSomething);
                    }

            return f[0, k, 0];
        }
    }
}
