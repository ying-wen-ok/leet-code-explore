using System;
using System.Collections.Generic;

namespace HashTable
{
    public class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            for(int i = 0; i < 9; i++)
            {
                if (!isValidRow(i, board)) return false;
                if (!isValidColumn(i, board)) return false;
            }

            for(int i = 0; i < 9; i = i + 3)
                for(int j = 0; j < 9; j = j + 3)
                {
                    if (!isValidBox(board, i, j)) return false;
                }

            return true;
        }
        private bool isEmpty(char c)
        {
            return c == '.';
        }

        private bool isValidRow(int row, char[][] board)
        {
            bool[] seen = new bool[10]; // dictionary of digits
            for(int i = 0; i < 9; i++)
            {
                if(isEmpty(board[row][i])) continue;
                int digit = board[row][i] - '0'; // key
                if (seen[digit]) return false;
                seen[digit] = true;
            }
            return true;
        }

        private bool isValidColumn(int column, char[][] board)
        {
            bool[] seen = new bool[10];
            for (int i = 0; i < 9; i++)
            {
                if (isEmpty(board[i][column])) continue;
                int digit = board[i][column] - '0';
                if (seen[digit]) return false;
                seen[digit] = true;
            }
            return true;
        }
    
        private bool isValidBox(char[][] board, int startRow, int startColumn)
        {
            bool[] seen = new bool[10];
            for (int row = startRow; row < startRow + 3; row++)
                for (int column = startColumn; column < startColumn + 3; column++)
                {
                    if (isEmpty(board[row][column])) continue;
                    int digit = board[row][column] - '0';
                    if (seen[digit]) return false;
                    seen[digit] = true;
                }
            return true;
        }
    }
}
