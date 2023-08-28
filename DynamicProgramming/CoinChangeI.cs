using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class CoinChangeI
    {
        public int CoinChange(int[] coins, int amount)
        {
            int n = coins.Length;
            int infinity = 10001;
            int[] f = new int[amount + 1];
            for (int i = 1; i <= amount; i++) f[i] = infinity;

            foreach (int coin in coins)
                for (int i = 0; i <= amount && i <= amount - coin; i++)
                    f[i + coin] = Math.Min(f[i + coin], f[i] + 1);
            return f[amount] == infinity ? -1 : f[amount];
        }
    }
}
