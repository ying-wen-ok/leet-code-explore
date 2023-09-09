using System;
using System.Collections.Generic;

namespace HashTable
{
    public class TwoSumIndex
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            int n = nums.Length;
            Dictionary<int, int> indexDict = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (indexDict.ContainsKey(target - nums[i]))
                {
                    result[0] = indexDict[target - nums[i]];
                    result[1] = i;
                    break;
                }
                else
                {
                    indexDict.TryAdd(nums[i], i);
                }
            }
            return result;
        }
    }
}
