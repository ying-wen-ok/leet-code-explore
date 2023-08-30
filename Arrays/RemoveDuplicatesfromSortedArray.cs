using System;
using System.Collections.Generic;

namespace Arrays
{
    public class RemoveDuplicatesfromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            int i = 0;
            int j = 0;
            int pre = -101;

            while (j < n)
            {
                if (nums[j] != pre)
                {
                    pre = nums[j];
                    nums[i] = nums[j];
                    i++;
                }
                j++;
            }
            return i;
        }
    }
}
