using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MaximumSumCircularSubarray
    {
        public int MaxSubarraySumCircular(int[] nums)
        {
            int n = nums.Length;
            int prefixSum = 0;

            int max = nums[0];
            int cur = nums[0];

            for (int i = 0; i < 2 * n; i++)
            {
                prefixSum += (i >= n ? nums[i - n] : nums[i]);
                cur = prefixSum - GetMinPrefixSum();
                max = Math.Max(max, cur);

                AddNewPrefixSum(prefixSum);
                if (dataQ.Count > n) DeleteOldPrefixSum();
            }
            return max;
        }

        private Queue<int> dataQ = new Queue<int>();
        private SortedDictionary<int, int> sortedData = new SortedDictionary<int, int>();

        private int GetMinPrefixSum()
        {
            if (sortedData.Count == 0) return 0;
            return sortedData.First().Key;
        }

        private void AddNewPrefixSum(int val)
        {
            dataQ.Enqueue(val);
            sortedData.TryAdd(val, 0);
            sortedData[val]++;
        }

        private void DeleteOldPrefixSum()
        {
            int deleteKey = dataQ.Dequeue();
            sortedData[deleteKey]--;
            if (sortedData[deleteKey] == 0) sortedData.Remove(deleteKey);
        }
    }
}
