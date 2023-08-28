using System;
using System.Collections.Generic;

namespace Graph
{
    public class PathWithMinimumEffort
    {
        public int MinimumEffortPath(int[][] heights)
        {
            int n = heights.Length;
            int m = heights[0].Length;

            int infinity = (int)1e9;
            int[,] minEffortToArrive = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    minEffortToArrive[i, j] = infinity;
                }

            PriorityQueue<(int i, int j, int maxEffort), int> pq = new PriorityQueue<(int i, int j, int maxEffort), int>();
            pq.Enqueue((0, 0, 0), 0);

            while (pq.Count > 0)
            {
                (int i, int j, int maxEffort) = pq.Dequeue();

                if (maxEffort > minEffortToArrive[i, j]) continue;
                minEffortToArrive[i, j] = maxEffort;

                // left
                if (i - 1 >= 0 && minEffortToArrive[i - 1, j] == infinity)
                {
                    int effortToTheNode = Math.Max(maxEffort, Math.Abs(heights[i][j] - heights[i - 1][j]));
                    pq.Enqueue((i - 1, j, effortToTheNode), effortToTheNode);
                }

                // right
                if (i + 1 < n && minEffortToArrive[i + 1, j] == infinity)
                {
                    int effortToTheNode = Math.Max(maxEffort, Math.Abs(heights[i][j] - heights[i + 1][j]));
                    pq.Enqueue((i + 1, j, effortToTheNode), effortToTheNode);
                }

                // top
                if (j - 1 >= 0 && minEffortToArrive[i, j - 1] == infinity)
                {
                    int effortToTheNode = Math.Max(maxEffort, Math.Abs(heights[i][j] - heights[i][j - 1]));
                    pq.Enqueue((i, j - 1, effortToTheNode), effortToTheNode);
                }

                // down
                if (j + 1 < m && minEffortToArrive[i, j + 1] == infinity)
                {
                    int effortToTheNode = Math.Max(maxEffort, Math.Abs(heights[i][j] - heights[i][j + 1]));
                    pq.Enqueue((i, j + 1, effortToTheNode), effortToTheNode);
                }
            }

            return minEffortToArrive[n - 1, m - 1];
        }

    }
}
