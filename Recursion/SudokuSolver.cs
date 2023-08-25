using System;
using System.Collections.Generic;

namespace Recursion
{
    public class SudokuSolver
    {
        public void SolveSudoku(char[][] _board)
        {
            board = _board;
            for (int i = 0; i <= 9; i++) values[i] = Convert.ToChar(i.ToString());
            fillTheCell(0, 0);
        }

        int n = 9;
        char[][] board;
        char[][] savedBoard;
        char empty = '.';
        char[] values = new char[10];
        bool found;
        private bool isTheMoveValid(int row, int column, char value)
        {
            // validate current column
            for (int i = 0; i < n; i++)
                if (board[i][column] == value) return false;

            // validate current row
            for (int j = 0; j < n; j++)
                if (board[row][j] == value) return false;

            // validate current sub-box
            int startRow = (row / 3) * 3;
            int startColumn = (column / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
                for (int j = startColumn; j < startColumn + 3; j++)
                    if (board[i][j] == value) return false;

            return true;
        }

        private void fillTheCell(int i, int j)
        {
            if (found) return;
            if (i == 9)
            {
                found = true;
                return;
            }
            if (board[i][j] != empty)
            {
                int nextJ = (j + 1) % n;
                int nextI = j + 1 == 9 ? i + 1 : i;
                fillTheCell(nextI, nextJ);
                return;
            }

            for (int value = 1; value <= 9; value++)
            {
                if (isTheMoveValid(i, j, values[value]))
                {
                    board[i][j] = values[value];

                    int nextJ = (j + 1) % n;
                    int nextI = j + 1 == 9 ? i + 1 : i;
                    fillTheCell(nextI, nextJ);
                    if (!found) board[i][j] = empty;
                }
            }
        }
    }

}
