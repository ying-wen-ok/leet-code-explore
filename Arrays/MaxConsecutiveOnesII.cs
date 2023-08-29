using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MaxConsecutiveOnesII
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int preOnes = 0;
            int curOnes = nums[0];
            int zeors = nums[0] == 0 ? 1 : 0;
            int max = 0;
            int n = nums.Length;

            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] == 0 && nums[i] == 0)
                {
                    zeors++;
                }
                else if (nums[i - 1] == 1 && nums[i] == 1)
                {
                    curOnes++;
                }
                else if (nums[i - 1] == 1 && nums[i] == 0)
                {
                    max = Math.Max(max, curOnes + 1 + (zeors <= 1 ? preOnes : 0));

                    preOnes = curOnes;
                    curOnes = 0;
                    zeors = 1;
                }
                else if (nums[i - 1] == 0 && nums[i] == 1)
                {
                    curOnes = 1;
                }
            }
            max = Math.Max(max, curOnes + (zeors > 0 ? 1 : 0) + (zeors <= 1 ? preOnes : 0));
            return max;
        }
    }
}
