using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MoveZeroesInArray
    {
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int i = 0;
            int j = 0;

            while (j < n && i < n)
            {
                if (nums[i] == 0)
                {
                    if (i == n - 1) break;

                    j = Math.Max(j, i + 1);
                    nums[i] = nums[j];
                    nums[j] = 0;
                    j++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
