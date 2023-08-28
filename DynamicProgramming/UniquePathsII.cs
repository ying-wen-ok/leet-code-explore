using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {

            int obstacle = 1;
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            int[,] dp = new int[m, n];

            dp[0, 0] = (obstacleGrid[0][0] == obstacle ? 0 : 1);
            for (int i = 1; i < m; i++) dp[i, 0] = (obstacleGrid[i][0] == obstacle ? 0 : dp[i - 1, 0]);
            for (int j = 1; j < n; j++) dp[0, j] = (obstacleGrid[0][j] == obstacle ? 0 : dp[0, j - 1]);

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    dp[i, j] = (obstacleGrid[i][j] == obstacle ? 0 : dp[i - 1, j] + dp[i, j - 1]);

            return dp[m - 1, n - 1];
        }
    }
}
