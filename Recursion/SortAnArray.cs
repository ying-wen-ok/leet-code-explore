using System;
using System.Collections.Generic;

namespace Recursion
{
    public class SortAnArray
    {
        public int[] SortArray(int[] _nums)
        {
            nums = _nums;
            return DivideAndConquer(0, _nums.Length - 1);
        }

        int[] nums;
        private int[] DivideAndConquer(int start, int end)
        {
            if (start >= end) return new int[] { nums[start] };

            int mid = start + (end - start) / 2;

            int[] leftHalf = DivideAndConquer(start, mid);
            int[] rightHalf = DivideAndConquer(mid + 1, end);

            return Merge(leftHalf, rightHalf);
        }


        //Merge Sort Array Topdown
        private int[] Merge(int[] l1, int[] l2)
        {
            int n1 = l1.Length;
            int n2 = l2.Length;
            int n = n1 + n2;
            int[] l = new int[n];

            int i = 0;
            int i1 = 0;
            int i2 = 0;
            while (i < n)
            {
                if (i1 < n1 && i2 < n2)
                {
                    if (l1[i1] <= l2[i2])
                    {
                        l[i] = l1[i1];
                        i1++;
                    }
                    else
                    {
                        l[i] = l2[i2];
                        i2++;
                    }
                }
                else if (i1 < n1)
                {
                    l[i] = l1[i1];
                    i1++;
                }
                else if (i2 < n2)
                {
                    l[i] = l2[i2];
                    i2++;
                }
                i++;
            }
            return l;
        }
    }
}
