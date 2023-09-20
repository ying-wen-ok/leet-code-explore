using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class TheFloodFill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            n = image.Length;
            m = image[0].Length;
            originalColor = image[sr][sc];
            changeColor = color;
            if (originalColor != changeColor) Flood(image, sr, sc);
            return image;
        }

        private (int i, int j)[] directions = new (int i, int j)[]
        {
            (1,0),
            (-1,0),
            (0,1),
            (0,-1),
        };
        private int n;
        private int m;
        private int changeColor;
        private int originalColor;
        private void Flood(int[][] image, int i, int j)
        {
            image[i][j] = changeColor;

            foreach (var direction in directions)
            {
                int nextI = i + direction.i;
                int nextJ = j + direction.j;

                if (nextI < 0 || nextJ < 0 || nextI >= n || nextJ >= m || image[nextI][nextJ] == changeColor || image[nextI][nextJ] != originalColor) continue;
                Flood(image, nextI, nextJ);
            }
        }
    }
}
