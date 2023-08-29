using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class SearchForARange
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0) return new int[] { -1, -1 };

            int[] range = new int[2];
            range[0] = binarySearchFirstAppearance(nums, target, n);
            range[1] = binarySearchLastAppearance(nums, target, n);
            return range;
        }

        private int binarySearchFirstAppearance(int[] nums, int target, int n)
        {
            int start = 0;
            int end = n - 1;
            int i;

            while (start <= end)
            {
                i = (start + end) / 2;
                if (nums[i] < target) start = i + 1;
                else end = i - 1;
            }

            return start < n && nums[start] == target ? start : -1;
        }

        private int binarySearchLastAppearance(int[] nums, int target, int n)
        {
            int start = 0;
            int end = n - 1;
            int i;

            while (start <= end)
            {
                i = (start + end) / 2;
                if (nums[i] > target) end = i - 1;
                else start = i + 1;
            }

            return end >= 0 && nums[end] == target ? end : -1;
        }
    }
}
