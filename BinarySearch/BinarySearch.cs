using System;
using System.Collections.Generic;


namespace BinarySearch
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            int mid = (left + right) / 2;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else if (nums[mid] > target) right = mid - 1;
            }

            return -1;
        }
    }
}
