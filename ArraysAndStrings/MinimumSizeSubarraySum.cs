using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int j = 0; // start of subarray
            int min = 1000001;
            int n = nums.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)  // end of subarray
            {
                sum += nums[i];

                while (sum > target)
                {
                    min = Math.Min(min, Math.Max(0, i - j + 1));
                    sum -= nums[j];
                    j++;
                }

                if (sum == target)
                {
                    min = Math.Min(min, Math.Max(0, i - j + 1));
                }
            }

            return min == 1000001 ? 0 : min;
        }
    }
}
