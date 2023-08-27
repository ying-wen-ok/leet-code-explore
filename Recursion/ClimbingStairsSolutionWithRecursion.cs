using System;
using System.Collections.Generic;

namespace Recursion
{
    public class ClimbingStairsSolutionWithRecursion
    {
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            stepsCount = new int[n + 1];
            stepsCount[1] = 1;
            stepsCount[2] = 2;
            for (int i = 3; i <= n; i++) stepsCount[i] = -1;
            return CountSteps(n);
        }

        int[] stepsCount;
        private int CountSteps(int stair)
        {
            if (stepsCount[stair] < 0)
                stepsCount[stair] = CountSteps(stair - 1) + CountSteps(stair - 2);
         
            return stepsCount[stair];
        }
    }
}
