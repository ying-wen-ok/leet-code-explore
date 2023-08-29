using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class IntersectionOfTwoArrays
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> data1 = nums1.ToHashSet();
            HashSet<int> result = new HashSet<int>();
            foreach (int i in nums2)
            {
                if (data1.Contains(i) && !result.Contains(i))
                    result.Add(i);
            }
            return result.ToArray();
        }
    }
}
