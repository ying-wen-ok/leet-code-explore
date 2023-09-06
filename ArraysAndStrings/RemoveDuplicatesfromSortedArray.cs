using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class RemoveDuplicatesfromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            int i = 1;
            int j = i;
            while(j < n && i < n)
            {
                if (nums[i] <= nums[i - 1]) 
                {
                    while (j < n && nums[j] <= nums[i - 1])
                    {
                        j++;
                    }
                    if (j == n) break;
                    nums[i] = nums[j];
                }
                i++;
            }
            return i;
        }
    }
}
