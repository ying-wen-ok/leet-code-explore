using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindMinimuminRotatedSortedArray
    {
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int target = nums[0];
            int start = 0;
            int end = n - 1;
            int i;
            while (start <= end)
            {
                i = (start + end) / 2;
                if (nums[i] >= target) start = i + 1;
                else if (nums[i] < target) end = i - 1;
            }
            if (start == n) return target;
            return nums[start];
        }
    }
}
