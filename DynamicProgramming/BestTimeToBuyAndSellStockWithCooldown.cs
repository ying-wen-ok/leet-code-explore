using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class BestTimeToBuyAndSellStockWithCooldown
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[,,] f = new int[n + 1, 2, 2];

            for (int i = n - 1; i >= 0; i--)
                for (int j = 1; j >= 0; j--) // j: bool value, holding now? 1: holding, 0: not holding
                    for (int k = 1; k >= 0; k--) // k: bool value, coolDown day? 1: yes, 0: no
                    {
                        int doNothing = f[i + 1, j, 0];
                        int doSomething = 0;

                        if (j == 1 && k == 0)
                        {
                            // sell
                            doSomething = prices[i] + f[i + 1, 0, 1];
                        }
                        else if (j == 0 && k == 0)
                        {
                            // buy
                            doSomething = -prices[i] + f[i + 1, 1, 0];
                        }

                        f[i, j, k] = Math.Max(doNothing, doSomething);
                    }
            return f[0, 0, 0];
        }
    }
}
