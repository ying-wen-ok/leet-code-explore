using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindMinimuminRotatedSortedArrayII
    {
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int lastElement = nums[n - 1];
            int pivotIndex = -1;
            int minVal = nums[0];
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > lastElement) { pivotIndex = i; break; }
                minVal = Math.Min(minVal, nums[i]);
            }
            if (pivotIndex == -1) { return minVal; }
            int pivotVal = nums[pivotIndex];
            int start = pivotIndex;
            int end = n - 1;
            int mid;
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (nums[mid] < pivotVal) end = mid - 1;
                else start = mid + 1;
            }

            if (start == n) return nums[0];
            return nums[start];
        }
    }
}
