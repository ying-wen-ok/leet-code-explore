using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindKClosestElements
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int n = arr.Length;
            int firstBiggerElementIndex = BinarySearch(arr, x);

            int[] result = new int[k];
            int big = firstBiggerElementIndex;
            int small = firstBiggerElementIndex - 1;

            int i = k - 1;
            while (i >= 0)
            {
                if (big < n && small >= 0)
                {
                    if (Math.Abs(arr[big] - x) < Math.Abs(arr[small] - x))
                    {
                        result[i] = arr[big];
                        big++;
                    }
                    else
                    {
                        result[i] = arr[small];
                        small--;
                    }
                }
                else if (small < 0)
                {
                    result[i] = arr[big];
                    big++;
                }
                else if (big >= n)
                {
                    result[i] = arr[small];
                    small--;
                }
                i--;
            }
            Array.Sort(result);
            return result;
        }



        private int BinarySearch(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            int i;

            while (start <= end)
            {
                i = (start + end) / 2;
                if (nums[i] < target) start = i + 1;
                else end = i - 1;
            }
            return start;
        }
    }
}
