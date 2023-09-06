using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class RotateArray
    {
       
        // O(k) space
        // O(n) time
        public void RotateII(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            int[] kNums = new int[k + 1];

            for (int i = 0; i < k; i++)
            {
                kNums[i] = nums[n - k + i];
            }

            for (int i = n - 1; i >= k; i--)
            {
                nums[i] = nums[i - k ];
            }

            for (int i = 0; i < k; i++)
            {
                nums[i] = kNums[i];
            }
        }

        // O(n) space
        // O(n) time
        public void RotateSolutionI(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            int[] newNums = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i - k >= 0) newNums[i] = nums[i - k];
                else newNums[i] = nums[n - k + i];
            }

            for (int i = 0; i < n; i++)
            {
                nums[i] = newNums[i];
            }
        }

    }
}