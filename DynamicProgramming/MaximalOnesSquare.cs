using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class MaximalOnesSquare
    {
        public int MaximalSquare(char[][] matrix)
        {
            int n = matrix.Length;
            int m = n == 0 ? 0 : matrix[0].Length;

            int[,] f = new int[n + 1, m + 1];
            int max = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '0') continue;

                    int onTop = (i == 0) ? 0 : f[i - 1, j];
                    int onLeft = (j == 0) ? 0 : f[i, j - 1];
                    int onConner = (i == 0 || j == 0) ? 0 : f[i - 1, j - 1];

                    int len = (int)Math.Sqrt(Math.Min(onConner, Math.Min(onTop, onLeft)));
                    f[i, j] = (len + 1) * (len + 1);
                    max = Math.Max(max, f[i, j]);
                }
            return max;
        }
    }
}
