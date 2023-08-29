using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MergeSortedArray
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int totalLength = m + n;
            for (int k = 1; k <= m; k++) swap(nums1, m - k, totalLength - k);

            int i1 = totalLength - m;
            int i2 = 0;

            int i = 0;
            while (i < totalLength)
            {
                if (i2 == n || (i1 < totalLength && nums1[i1] <= nums2[i2]))
                {
                    swap(nums1, i1, i);
                    i1++;
                }
                else
                {
                    nums1[i] = nums2[i2];
                    i2++;
                }
                i++;
            }
        }

        private void swap(int[] nums1, int i, int j)
        {
            int temp = nums1[i];
            nums1[i] = nums1[j];
            nums1[j] = temp;
        }
    }
}