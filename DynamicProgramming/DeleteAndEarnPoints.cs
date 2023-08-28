using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class DeleteAndEarnPoints
    {
        public int DeleteAndEarn(int[] nums)
        {
            int n = 10001;
            int[] data = new int[n];
            foreach (int i in nums) data[i]++;

            int[] dp = new int[3];
            dp[0] = data[0] * 0;
            dp[1] = data[1] * 1;

            for (int i = 2; i < n; i++)
            {
                dp[2] = Math.Max(dp[1], dp[0] + data[i] * i);
                dp[0] = dp[1];
                dp[1] = dp[2];
            }
            return Math.Max(dp[1], dp[0]);
        }
    }
}
