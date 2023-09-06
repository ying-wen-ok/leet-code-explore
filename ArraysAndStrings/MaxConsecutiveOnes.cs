using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        { 
            int n = nums.Length;
           
            int j = -1; // start of '1'

            int max = 0;
            for(int i = 0; i < n; i++) // end of '1'
            {
                if (nums[i] == 1)
                {
                    if (j == -1) j = i;
                    max = Math.Max(max, i - j + 1);                    
                }
                else
                {
                    j = -1;
                }
            }   
            return max;
        }
    }
}
