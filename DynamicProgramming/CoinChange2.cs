using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class CoinChange2
    {
        public int Change(int amount, int[] coins)
        {

            int[] f = new int[amount + 1];
            f[0] = 1;
            foreach (int coin in coins)
            {
                for (int i = 0; i <= amount && coin + i <= amount; i++)
                {
                    f[i + coin] += f[i];
                }
            }
            return f[amount];
        }
    }
}
