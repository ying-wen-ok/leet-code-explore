using System;
using System.Collections.Generic;

namespace Graph
{
    public class RottingOranges
    {
        public int OrangesRotting(int[][] _grid)
        {
            grid = _grid;
            n = grid.Length;
            m = grid[0].Length;
            rottenOrangesQ = new Queue<(int i, int j, int t)>();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == freshOrange) countOfFreshOrange++;
                    else if (grid[i][j] == rottenOrange) rottenOrangesQ.Enqueue((i, j, 0));
                }

            if (countOfFreshOrange == 0) return 0;
            if (rottenOrangesQ.Count == 0) return -1;

            while (rottenOrangesQ.Count > 0)
            {
                (int i, int j, int t) = rottenOrangesQ.Dequeue();
                time = Math.Max(time, t);
                tryOneDirection(i + 1, j, t + 1);
                tryOneDirection(i - 1, j, t + 1);
                tryOneDirection(i, j + 1, t + 1);
                tryOneDirection(i, j - 1, t + 1);
            }
            if (countOfFreshOrange > 0) return -1;
            return time;
        }

        int[][] grid;
        int n;
        int m;
        int emptyCell = 0;
        int freshOrange = 1;
        int rottenOrange = 2;
        int countOfFreshOrange = 0;
        int time = 0;
        Queue<(int i, int j, int t)> rottenOrangesQ;
        private void tryOneDirection(int i, int j, int t)
        {
            if (i < 0 || j < 0 || i >= n || j >= m) return;
            if (grid[i][j] == freshOrange)
            {
                grid[i][j] = rottenOrange;
                countOfFreshOrange--;
                rottenOrangesQ.Enqueue((i, j, t));
            }
        }
    }
}
