using System;
using System.Collections.Generic;

namespace Arrays
{
    public class SquaresofaSortedArray
    {
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            if (nums[n - 1] <= 0) return solutionForNegtiveNumbers(nums, n);
            if (nums[0] >= 0) return solutionForPositiveNumbers(nums, n);

            return solutionForPartialopositveNumbers(nums, n);
        }

        private int[] solutionForNegtiveNumbers(int[] nums, int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = nums[n - i - 1] * nums[n - i - 1];
            }

            return result;
        }

        private int[] solutionForPositiveNumbers(int[] nums, int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = nums[i] * nums[i];
            }

            return result;
        }

        private int[] solutionForPartialopositveNumbers(int[] nums, int n)
        {
            int[] result = new int[n];
            int head = 0;
            int tail = n - 1;

            for (int i = n - 1; i >= 0; i--)
            {
                int headAbs = Math.Abs(nums[head]);
                int tailAbs = Math.Abs(nums[tail]);

                int num;
                if (headAbs > tailAbs)
                {
                    num = headAbs;
                    head++;
                }
                else
                {
                    num = tailAbs;
                    tail--;
                }

                result[i] = num * num;
            }
            return result;
        }
    }
}
