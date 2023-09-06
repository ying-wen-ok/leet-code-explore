using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class ArrayPartitionI
    {
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int sum = 0;
            for (int i = n - 2; i >= 0; i = i - 2)
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}
