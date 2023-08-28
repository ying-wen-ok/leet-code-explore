using System;
using System.Collections.Generic;

namespace Graph
{
    public class ShortestPathInBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] _grid)
        {
            grid = _grid;
            if (grid[0][0] == 1) return -1;
            n = grid.Length;

            (int i, int j) start = (0, 0);
            (int i, int j) end = (n - 1, n - 1);

            visited = new bool[n, n];
            Q = new Queue<(int i, int j, int distance)>();
            Q.Enqueue((start.i, start.j, 1));

            while (Q.Count > 0)
            {
                (int i, int j, int distance) = Q.Dequeue();
                if ((i, j) == end) return distance;

                if (visited[i, j]) continue;
                visited[i, j] = true;

                tryNext(i, j + 1, distance + 1);
                tryNext(i, j - 1, distance + 1);
                tryNext(i + 1, j, distance + 1);
                tryNext(i - 1, j, distance + 1);

                tryNext(i + 1, j + 1, distance + 1);
                tryNext(i + 1, j - 1, distance + 1);
                tryNext(i - 1, j + 1, distance + 1);
                tryNext(i - 1, j - 1, distance + 1);
            }
            return -1;
        }
        int[][] grid;
        Queue<(int i, int j, int distance)> Q;
        bool[,] visited;
        int n;
        private void tryNext(int i, int j, int d)
        {
            if (i < 0 || i >= n || j < 0 || j >= n) return;
            if (visited[i, j] || grid[i][j] == 1) return;
            Q.Enqueue((i, j, d));
        }
    }
}
