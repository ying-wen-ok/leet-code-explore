using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] f = new int[n];

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = i; j >= 0; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        count = Math.Max(count, f[j]);
                    }
                }
                f[i] = count + 1;
            }
            return f.Max();
        }
    }
}
