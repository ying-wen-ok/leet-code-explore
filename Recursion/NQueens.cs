using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class NQueens
    {
        public int TotalNQueens(int _n)
        {
            n = _n;
            board = new int[n, n];

            PlaceAtRow(0);
            return total;
        }

        int[,] board;
        int n;
        int total = 0;
        private void PlaceAtRow(int i)
        {
            if (i == n)
            {
                total++;
                return;
            }

            for (int j = 0; j < n; j++)
            {
                board[i, j] = 1;
                if (IsBoardValid()) PlaceAtRow(i + 1);
                board[i, j] = 0;
            }
        }

        private bool IsBoardValid()
        {
            for (int i = 0; i < n; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < n; j++)
                {
                    rowSum += board[i, j];
                    if (rowSum > 1) return false;
                }
            }

            for (int j = 0; j < n; j++)
            {
                int columnSum = 0;
                for (int i = 0; i < n; i++)
                {
                    columnSum += board[i, j];
                    if (columnSum > 1) return false;
                }
            }

            int diagnalSum = 0;
            for (int j = 0; j < n; j++)
            {
                int i = 0;
                diagnalSum = 0;

                for (int k = 0; k < n; k++)
                {
                    int nextI = i + k;
                    int nextJ = j - k;
                    if (nextI >= n || nextJ < 0) break;
                    diagnalSum += board[nextI, nextJ];
                    if (diagnalSum > 1) return false;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int j = n - 1;
                diagnalSum = 0;

                for (int k = 0; k < n; k++)
                {
                    int nextI = i + k;
                    int nextJ = j - k;
                    if (nextI >= n || nextJ < 0) break;
                    diagnalSum += board[nextI, nextJ];
                    if (diagnalSum > 1) return false;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int j = 0;
                diagnalSum = 0;

                for (int k = 0; k < n; k++)
                {
                    int nextI = i + k;
                    int nextJ = j + k;
                    if (nextI >= n || nextJ >= n) break;
                    diagnalSum += board[nextI, nextJ];
                    if (diagnalSum > 1) return false;
                }
            }

            for (int j = 0; j < n; j++)
            {
                int i = 0;
                diagnalSum = 0;

                for (int k = 0; k < n; k++)
                {
                    int nextI = i + k;
                    int nextJ = j + k;
                    if (nextI >= n || nextJ >= n) break;
                    diagnalSum += board[nextI, nextJ];
                    if (diagnalSum > 1) return false;
                }
            }
            return true;
        }
    }

}
