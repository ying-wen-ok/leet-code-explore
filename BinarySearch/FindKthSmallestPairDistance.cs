using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindKthSmallestPairDistance
    {
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums); // o( n*logn )
            int n = nums.Length;
            int maxDistance = nums[n - 1] - nums[0];

            int end = maxDistance;
            int start = 0; // minDistance
            int i;
            int countOfPairs;

            while (start <= end)
            {
                i = (start + end) / 2;
                countOfPairs = countPairs(i, nums, n);
                if (countOfPairs < k) start = i + 1;
                else end = i - 1;
            }
            return Math.Min(start, maxDistance);
        }

        private int countPairs(int targetDistance, int[] nums, int n)
        {
            int totalCoutOfPairs = 0;
            int j = 0;
            for (int i = 0; i < n && j < n; i++)
            {

                while (j < n - 1)
                {
                    if (nums[j + 1] - nums[i] <= targetDistance) j++;
                    else break;
                }

                totalCoutOfPairs += j - i;
            }
            return totalCoutOfPairs;
        }
    }
}
