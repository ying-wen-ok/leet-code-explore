using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class NumberOfDiceRollsWithTargetSum
    {
        public int NumRollsToTarget(int n, int k, int target)
        {
            int modulo = (int)1e9 + 7;
            int[,] dp = new int[n + 1, target + 1];
            for (int j = 1; j <= k && j <= target; j++) dp[1, j] = 1;

            for (int i = 2; i <= n; i++)
                for (int sum = 1; sum <= target; sum++)
                    for (int j = 1; j <= k; j++)
                    {
                        if (sum - j < 1) continue;
                        dp[i, sum] += dp[i - 1, sum - j];
                        dp[i, sum] = dp[i, sum] % modulo;
                    }

            return dp[n, target];
        }
    }
}
