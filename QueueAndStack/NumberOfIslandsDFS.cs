using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class NumberOfIslandsDFS
    {
        public int NumIslands(char[][] grid)
        {
            map = grid;
            n = grid.Length;
            m = grid[0].Length;

            int countOfIsland = 0;
            for(int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (map[i][j] == land)
                    {
                        countOfIsland++;
                        FloodTheIsland(i, j);
                    }
                }
            return countOfIsland;
        }

        private char water = '0';
        private char land = '1';
        private (int i, int j)[] directions = new (int i, int j)[] 
        {
            (0,-1),
            (0,1),
            (-1,0),
            (1,0)
        };

        private char[][] map;
        private int n;
        private int m;

        private void FloodTheIsland(int i, int j)
        {
            if (i < 0 || j < 0 || i >= n || j >= m || map[i][j] == water) return;
            map[i][j] = water;
            foreach(var direction in directions)
                FloodTheIsland(i + direction.i, j + direction.j);
        }
    }
}
