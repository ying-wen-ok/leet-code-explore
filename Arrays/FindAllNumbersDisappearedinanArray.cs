using System;
using System.Collections.Generic;

namespace Arrays
{
    public class FindAllNumbersDisappearedinanArray
    {
        // Solution without extra space and in O(n) runtime. You may assume the returned list does not count as extra space.
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int expecting = i + 1;
                while (nums[i] != expecting)
                {
                    int j = nums[i] - 1;
                    if (nums[j] == nums[i]) break;
                    swap(nums, i, j);
                }
            }

            List<int> missing = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int expecting = i + 1;
                int actual = nums[i];
                if (actual != expecting) missing.Add(expecting);
            }
            return missing;
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
