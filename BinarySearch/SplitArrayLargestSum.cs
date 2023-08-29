using System;
using System.Collections.Generic;

namespace BinarySearch
{
    internal class SplitArrayLargestSum
    {
        public int SplitArray(int[] nums, int m)
        {
            int infinity = (int)1e9;
            int n = nums.Length;
            SetRangeSum(nums, n);

            int[,] f = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
                for (int j = 0; j <= n; j++)
                    f[i, j] = infinity;

            f[0, 0] = 0;

            for (int i = 0; i < m; i++)
            {
                for (int jTarget = 1; jTarget <= n; jTarget++)
                {
                    for (int j = 0; j < jTarget; j++)
                    {
                        int oldRange = f[i, j];
                        int newRange = GetRangeSum(j + 1, jTarget);

                        int fij = Math.Max(oldRange, newRange);
                        f[i + 1, jTarget] = Math.Min(f[i + 1, jTarget], fij);
                    }
                }
            }
            return f[m, n];
        }

        /// shift index i by +1
        /// preI[i]:    sum(nums[0] ... nums[i-1]) 
        /// preI[0]:    0
        /// preI[1]:    nums[0]
        /// preI[n]:    sum(nums[0] ... nums[n-1]) 
        int[] preI;
        private void SetRangeSum(int[] nums, int n)
        {
            preI = new int[n + 1];
            for (int i = 1; i <= n; i++) preI[i] = preI[i - 1] + nums[i - 1];
        }

        /// <summary>
        ///  return range sum[i,j]
        ///  inlcuding num[i], num[j]
        /// </summary>
        /// <param name="start">start index</param>
        /// <param name="end">end index</param>
        private int GetRangeSum(int start, int end)
        {
            return preI[end] - preI[start - 1];
        }

    }
}
