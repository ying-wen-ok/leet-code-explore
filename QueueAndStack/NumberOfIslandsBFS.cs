using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace QueueAndStack
{
    public class NumberOfIslandsBFS
    {
        public int NumIslands(char[][] grid)
        {
            char land = '1';
            char water = '0';

            (int i, int j)[] directions = new (int i, int j)[4]
            {
                (0, 1),
                (0, -1),
                (1, 0),
                (-1, 0),
            };

            int m = grid.Length;
            int n = grid[0].Length;

            int count = 0;
            for(int i = 0; i < m; i++)
                for(int j = 0; j < n; j++)
                {
                    if (grid[i][j] == land)
                    {
                        FloodThisIsland(grid, (i, j), m, n, water, land, directions);
                        count++;
                    }
                }
            return count;
        }

        private void FloodThisIsland(char[][] grid, (int i, int j) location, int m, int n, char flood, char land, (int i, int j)[] directions)
        {
            Queue<(int i, int j)> floodedLands = new Queue<(int i, int j)>();
            floodedLands.Enqueue(location);
            grid[location.i][location.j] = flood;

            while (floodedLands.Count > 0)
            {
                (int i, int j) floodedLand = floodedLands.Dequeue();

                foreach(var direction in directions)
                {
                    int nextI = floodedLand.i + direction.i;
                    int nextJ = floodedLand.j + direction.j;

                    if(nextI >= 0 && nextJ >= 0 && nextI < m && nextJ < n && grid[nextI][nextJ] == land)
                    {
                        grid[nextI][nextJ] = flood;
                        floodedLands.Enqueue((nextI, nextJ));
                    }
                }
            }
        }
    }
}
