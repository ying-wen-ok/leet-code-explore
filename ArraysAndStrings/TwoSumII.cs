using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class TwoSumII
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;
            while (i < j)
            {
                int sum = numbers[i] + numbers[j];
                if (sum == target) break;
                else if (sum > target) j--;
                else if (sum < target) i++;
            }
            return new int[] { i + 1, j + 1 };
        }
    }
}
