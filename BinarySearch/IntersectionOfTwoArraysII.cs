using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class IntersectionOfTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            foreach (int i in nums1)
            {
                dict1.TryAdd(i, 0);
                dict1[i]++;
            }
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            foreach (int i in nums2)
            {
                dict2.TryAdd(i, 0);
                dict2[i]++;
            }

            List<int> result = new List<int>();
            foreach (var i in dict1)
            {
                if (dict2.ContainsKey(i.Key))
                {
                    int count = Math.Min(i.Value, dict2[i.Key]);

                    for (int j = 0; j < count; j++)
                    {
                        result.Add(i.Key);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
