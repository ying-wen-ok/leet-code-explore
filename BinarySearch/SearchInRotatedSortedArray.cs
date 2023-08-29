using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            int n = nums.Length;
      
            int k = BinarySearchKIndex(nums);
            if (nums[k] == target) return k;

            int targetIndex;
            targetIndex = BinarySearch(0, k - 1, target, nums); // search agianst [0 , k - 1]
            if (targetIndex != -1) return targetIndex;

            targetIndex = BinarySearch(k + 1, n - 1, target, nums); // search agianst [k + 1, n - 1]
            return targetIndex;
        }

        // search for the piviot index, k, against the [1, n - 1]  
        // nums[0] can be use as a special number, because  nums[1, .., k - 1] > nums[0]
        // and nums[k,k + 1, .., n - 1]  < nums[0]
        private int BinarySearchKIndex( int[] nums)
        {
            int specialNumber = nums[0];
            int start = 1;
            int end = nums.Length - 1;
            int i;
            while (end >= start)
            {
                i = (start + end) / 2;
                if (nums[i] >= specialNumber) start = i + 1;
                else end = i - 1;
            }
            return (start == nums.Length) ? start - 1 : start;
        }

        private int BinarySearch(int start, int end, int target, int[] nums)
        {
            int i;
            while (end >= start)
            {
                i = (start + end) / 2;

                if (target < nums[i]) end = i - 1;
                else if (target > nums[i]) start = i + 1;
                else return i;
            }
            return -1;
        }

    }
}
