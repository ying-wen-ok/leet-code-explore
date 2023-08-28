using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MinimumDifficultyOfAJobSchedule
    {
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;
            if (d > n) return -1;
            SetMaxOfRange(jobDifficulty);

            int[,] f = new int[d + 1, n];

            int curMax = 0;
            for (int j = 0; j < n; j++)
            {
                curMax = Math.Max(curMax, jobDifficulty[j]);
                f[1, j] = curMax;
            }

            int infinity = 10 * 1000 + 1;
            for (int i = 2; i <= d; i++)
                for (int j = 0; j < n; j++)
                    f[i, j] = infinity;

            for (int i = 2; i <= d; i++)
            {
                int firstPossibleJobIndexToEndToday = i - 1;
                int lastPossibleJobIndexToEndToday = n - 1 - (d - i);

                for (int j = firstPossibleJobIndexToEndToday; j <= lastPossibleJobIndexToEndToday; j++)
                {
                    int lastPossibleJobIndexToStartToday = j;
                    int firstPossibleJobIndexToStartToday = i - 1;

                    for (int k = firstPossibleJobIndexToStartToday; k <= lastPossibleJobIndexToStartToday; k++)
                    {
                        int effortOfToday = GetMaxOfRange(k, j);
                        f[i, j] = Math.Min(f[i, j], effortOfToday + f[i - 1, k - 1]);
                    }
                }
            }
            return f[d, n - 1] == infinity ? -1 : f[d, n - 1];
        }

        private int[,] rangeMax;

        private void SetMaxOfRange(int[] nums)
        {
            int n = nums.Length;
            rangeMax = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int max = nums[i];
                for (int j = i; j < n; j++)
                {
                    max = Math.Max(max, nums[j]);
                    rangeMax[i, j] = max;
                }
            }
        }

        private int GetMaxOfRange(int start, int end)
        {
            return rangeMax[start, end];
        }
    }
}
