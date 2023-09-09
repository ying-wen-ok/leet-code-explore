using System;
using System.Collections.Generic;

namespace HashTable
{
    public class ContainsDuplicateII
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            int n = nums.Length;
            Dictionary<int, int> indexDict = new Dictionary<int, int>();
            for(int i = 0; i < n;i++)
            {
                int num = nums[i];
                if (indexDict.ContainsKey(num))
                {
                    int preIndex = indexDict[num];
                    if (i - preIndex <= k) return true;
                    else indexDict[num] = i;
                }
                else
                {
                    indexDict.Add(num, i);
                }
            }

            return false;
        }
    }
}
