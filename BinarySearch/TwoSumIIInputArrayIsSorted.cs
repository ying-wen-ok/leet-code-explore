using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class TwoSumIIInputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int n = numbers.Length;
            int i = 0;
            int j = n - 1;
            int[] result = new int[] { 1, 1 };

            while (i < j)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    result[0] += i;
                    result[1] += j;
                    break;
                }
                else if (numbers[i] + numbers[j] < target) i++;
                else if (numbers[i] + numbers[j] > target) j--;
            }

            return result;
        }
    }
}
