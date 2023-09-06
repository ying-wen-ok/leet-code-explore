using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class MoveZeroe
    {
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int i = 0;
            int j = 0;

            while(i < n && j < n)
            {
                if (nums[i] != 0)
                {
                    i++;
                    continue;
                }
                j = Math.Max(j, i + 1);
                while (j < n && nums[j] == 0)
                {
                    j++;
                }
                if (j == n) break;
                nums[i] = nums[j];
                nums[j] = 0;
                i++;
            }
        }
    }
}
