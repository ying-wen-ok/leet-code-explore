using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace HashTable
{
    public class IntersectionofTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> count1 = new Dictionary<int, int>();
            Dictionary<int, int> count2 = new Dictionary<int, int>();

            CountNumber(count1, nums1);
            CountNumber(count2, nums2);

            List<int> intersections = new List<int>();
            foreach(var i1 in count1)
            {
                int number = i1.Key;
                if (count2.ContainsKey(number))
                {
                    FillNumber(intersections, number, Math.Min(count1[number], count2[number]));
                }
            }
            return intersections.ToArray();
        }

        private void CountNumber(Dictionary<int, int> count, int[] nums)
        {
            int n = nums.Length;          

            for (int i = 0; i < n; i++)
            {
                int num = nums[i];
                count.TryAdd(num, 0);
                count[num]++;
            }           
        }

        private void FillNumber(List<int> result, int number, int count)
        {
            while(count > 0)
            {
                result.Add(number);
                count--;
            }
        }
    }
}
