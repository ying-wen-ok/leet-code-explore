using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    internal class MinCostClimbingStair
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int x0 = cost[0];
            int x1 = cost[1];
            int cur = 0;
            for (int i = 2; i < n; i++)
            {
                cur = Math.Min(cost[i] + x0, cost[i] + x1);

                x0 = x1;
                x1 = cur;
            }

            return Math.Min(x0, x1);
        }
    }
}
