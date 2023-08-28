using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MaximumScoreFromPerformingMultiplicationOperations
    {
        public int MaximumScore(int[] nums, int[] multipliers)
        {
            int min = -1 * 300 * 1000 * 1000;
            int n = multipliers.Length;
            int x = nums.Length;

            int[,] dp = new int[n + 1, x + 2];
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= x + 1; j++)
                    dp[i, j] = min;

            dp[0, 0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int multiplier = multipliers[i];
                    int leftIndex = j;
                    int rightIndex = x - 1 - (i - j);

                    dp[i + 1, leftIndex] = Math.Max(dp[i + 1, leftIndex], multiplier * nums[rightIndex] + dp[i, j]);
                    dp[i + 1, leftIndex + 1] = Math.Max(dp[i + 1, leftIndex + 1], multiplier * nums[leftIndex] + dp[i, j]);
                }
            }
            int max = min;
            for (int i = 0; i <= x; i++) max = Math.Max(dp[n, i], max);
            return max;
        }
    }
}
