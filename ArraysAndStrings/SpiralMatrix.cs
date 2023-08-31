using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] _matrix)
        {
            matrix = _matrix;
            n = matrix.Length;
            m = matrix[0].Length;
            i = 0;
            j = 0;

            visited = new bool[n, m];
            data = new int[n * m];

            int direction = 0;
            visited[0, 0] = true;
            data[0] = matrix[0][0];
            cur = 1;
            while (cur < n * m)
            {
                go(directions[direction]);
                direction = (direction + 1) % 4;
            }
            return data;
        }

        (int i, int j)[] directions = new (int i, int j)[4]
            {
               (0,1), /// right
               (1,0), /// down
               (0,-1), /// left
               (-1,0), /// up
            };
        int[][] matrix;
        int cur;
        int n;
        int m;
        int i;
        int j;
        bool[,] visited;
        int[] data;
        private void go((int i, int j) d)
        {
            int nexti = i + d.i;
            int nextj = j + d.j;
            if (cur >= n * m || nexti < 0 || nextj < 0 || nexti >= n || nextj >= m || visited[nexti, nextj]) return;

            i = nexti;
            j = nextj;
            visited[i, j] = true;
            data[cur] = matrix[i][j];
            cur++;
            go(d);
        }
    }
}
