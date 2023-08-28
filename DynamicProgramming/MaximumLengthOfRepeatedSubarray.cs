using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MaximumLengthOfRepeatedSubarray
    {
        public int FindLength(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            int[,] dp = new int[n1 + 1, n2 + 1];
            int max = 0;

            for (int i = 1; i <= n1; i++)
                for (int j = 1; j <= n2; j++)
                {
                    dp[i, j] = nums1[i - 1] == nums2[j - 1] ? dp[i - 1, j - 1] + 1 : 0;
                    max = Math.Max(max, dp[i, j]);
                }
            return max;
        }
    }
}
