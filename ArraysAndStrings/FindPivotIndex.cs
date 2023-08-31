using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class FindPivotIndex
    {
        public int PivotIndex(int[] nums)
        {
            int n = nums.Length;
            int[] left = new int[n]; // sum of the elements in range [0,i)
            int[] right = new int[n];// sum of the elements in range (i,n - 1]

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                left[i] = sum;
                sum += nums[i];    
            }

            sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                right[i] = sum;
                sum += nums[i];
            }

            for (int i = 0; i < n; i++)
            {
                if (left[i] == right[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

