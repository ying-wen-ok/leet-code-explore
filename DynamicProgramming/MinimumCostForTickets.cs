using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MinimumCostForTickets
    {
        public int MincostTickets(int[] days, int[] costs)
        {
            int n = days.Length;
            int lastDay = days[n - 1];

            int infinity = (int)1e9;
            int[] dp = new int[lastDay + 1];
            for (int i = 0; i <= lastDay; i++) dp[i] = infinity;

            for (int i = 0; i < n; i++)
            {
                int day = days[i];
                int previousDaysExpense = i == 0 ? 0 : dp[days[i - 1]];

                dp[day] = Math.Min(dp[day], previousDaysExpense + costs[0]);

                for (int x = day; x < day + 7 && x <= lastDay; x++)
                {
                    dp[x] = Math.Min(dp[x], previousDaysExpense + costs[1]);
                }

                for (int x = day; x < day + 30 && x <= lastDay; x++)
                {
                    dp[x] = Math.Min(dp[x], previousDaysExpense + costs[2]);
                }
            }

            return dp[lastDay];
        }
    }
}
