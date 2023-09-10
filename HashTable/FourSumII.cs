using System;
using System.Collections.Generic;

namespace HashTable
{
    public class FourSumII
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Dictionary<int, int> sum12 = GetSumDict(nums1, nums2);
            Dictionary<int, int> sum34 = GetSumDict(nums3, nums4);
            int count = 0;
            foreach (int key in sum12.Keys)
            {
                if (sum34.ContainsKey(-key))
                {
                    count += sum12[key] * sum34[-key];
                }
            }
            return count;
        }

        private Dictionary<int, int> GetSumDict(int[] x, int[] y)
        {
            Dictionary<int, int> sumDict = new Dictionary<int, int>();
            foreach (int i in x)
                foreach (int j in y)
                {
                    int sum = i + j;
                    sumDict.TryAdd(sum, 0);
                    sumDict[sum]++;
                }
            return sumDict;
        }
    }
}
