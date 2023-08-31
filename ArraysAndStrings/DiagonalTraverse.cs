using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class DiagonalTraverse
    {
        public int[] FindDiagonalOrder(int[][] _mat)
        {
            mat = _mat;
            int n = mat.Length;
            int m = mat[0].Length;
            data = new int[n * m];
            cur = -1;

            int i = 0;
            int j = 0;

            while (i >= 0 && j >= 0 && i < n && j < m)
            {
                goUp(ref i, ref j);

                if(j + 1 < m) j++;
                else i++;

                if (i == n) break;
                goDown(ref i, ref j);

                if (i + 1 < n) i++;
                else j++;
                if(j == m) break;
            }

            return data;
        }

        int cur;
        int[] data;
        int[][] mat;
        int n;
        int m;
        private void goUp(ref int i, ref int j)
        {
            cur++;
            data[cur] = mat[i][j];

            if (i - 1 < 0 || j + 1 == m) return;
            i--;
            j++;
            goUp(ref i, ref j);
        }

        private void goDown(ref int i, ref int j)
        {
            cur++;
            data[cur] = mat[i][j];

            if (i + 1 == n || j - 1 < 0) return;
            i++;
            j--;
            goDown(ref i, ref j);
        }
    }
}
