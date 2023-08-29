using System;
using System.Collections.Generic;

namespace Arrays
{
    public class ThirdMaximumNumber
    {
        //  O(n) solution
        public int ThirdMax(int[] nums)
        {
            int n = nums.Length;

            int max = nums[0];
            int min = nums[0];
            foreach (int i in nums)
            {
                max = Math.Max(max, i);
                min = Math.Min(min, i);
            }

            int secondMax = min;
            foreach (int i in nums)
            {
                if (i == max) continue;
                secondMax = Math.Max(secondMax, i);
            }

            int thirdMax = min;
            foreach (int i in nums)
            {
                if (i >= secondMax) continue;
                thirdMax = Math.Max(thirdMax, i);
            }

            if (max == secondMax || secondMax == thirdMax) return max;
            return thirdMax;
        }
    }
}
