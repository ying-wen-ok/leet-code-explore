using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    public class DominoandTrominoTiling
    {
        public int NumTilings(int n)
        {
            if (n == 1) return 1;

            int modulo = (int)1e9 + 7;
            long[,] dp = new long[n + 1, 3];

            dp[1, 2] = 1;
            dp[2, 0] = 1;
            dp[2, 1] = 1;
            dp[2, 2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 1] + dp[i - 2, 2];

                dp[i, 1] = dp[i - 1, 0] + dp[i - 2, 2];

                dp[i, 2] = (dp[i - 2, 2]
                           + dp[i - 1, 0]
                           + dp[i - 1, 1]
                           + dp[i - 1, 2]
                           ) % modulo;
            }
            return (int)dp[n, 2];
        }
    }
}
