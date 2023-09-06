using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class RemoveElements
    {
        public int RemoveElement(int[] nums, int val)
        {
            int n = nums.Length;
            int i = 0;
            int j = n - 1;
           
            while (i <= j)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[j];
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
    }
}
