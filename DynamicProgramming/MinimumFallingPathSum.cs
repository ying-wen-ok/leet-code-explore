using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MinimumFallingPathSum
    {
        public int MinFallingPathSum(int[][] matrix)
        {
            int uppperBound = (int)1e9;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] dp = new int[m, n];
            for (int j = 0; j < n; j++) { dp[0, j] = matrix[0][j]; }

            for (int i = 1; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    int dpAbove = dp[i - 1, j];
                    int dpDiagonallyLeft = (j - 1 >= 0) ? dp[i - 1, j - 1] : uppperBound;
                    int dpDiagonallyRight = (j + 1 < n) ? dp[i - 1, j + 1] : uppperBound;

                    dp[i, j] = matrix[i][j] +
                            Math.Min(dpAbove, Math.Min(dpDiagonallyLeft, dpDiagonallyRight));
                }

            int min = uppperBound;
            for (int j = 0; j < n; j++) min = Math.Min(min, dp[m - 1, j]);
            return min;
        }
    }
}
