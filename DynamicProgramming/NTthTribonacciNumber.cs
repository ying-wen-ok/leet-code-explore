using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class NTthTribonacciNumber
    {
        public int Tribonacci(int n)
        {
            int dp0 = 0;
            if (n == 0) return dp0;
            int dp1 = 1;
            int dp2 = 1;
            int cur = 1;
            for (int i = 3; i <= n; i++)
            {
                cur = dp0 + dp1 + dp2;
                dp0 = dp1;
                dp1 = dp2;
                dp2 = cur;
            }
            return cur;

        }
    }
}
