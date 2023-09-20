using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class Matrix01
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            matrix = mat;
            n = mat.Length;
            m = mat[0].Length;
            distance = new int[n][];
            for (int i = 0; i < n; i++)
            {
                distance[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    distance[i][j] = mat[i][j] == 0 ? 0 : maxDistance;
                }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        updateDistance(i, j);
                    }
                }

            return distance;
        }

        private int n;
        private int m;
        private int[][] distance;
        private int[][] matrix;
        private int maxDistance = 100000;
        private (int i, int j)[] directions = new (int i, int j)[]
            {
                (0,1),
                 (0,-1),
                  (1,0),
                   (-1,0)
            };

        private void updateDistance(int i, int j)
        {
            foreach (var d in directions)
            {
                int nextI = i + d.i;
                int nextJ = j + d.j;

                if (nextI < 0 || nextJ < 0 || nextI >= n || nextJ >= m
                 || distance[nextI][nextJ] <= distance[i][j] + 1
                    ) continue;

                distance[nextI][nextJ] = distance[i][j] + 1;
                updateDistance(nextI, nextJ);
            }
        }
    }
}
