using System;
using System.Collections.Generic;

namespace Recursion
{
    public class SearchA2DMatrixII
    {
        int m;
        int n;
        int[][] map;
        int t;
        bool found = false;
        public bool SearchMatrix(int[][] matrix, int target)
        {
            m = matrix.Length;
            n = matrix[0].Length;
            map = matrix;
            t = target;

            SearchArea((0, 0), (m - 1, n - 1));
            return found;
        }

        private void SearchArea((int i, int j) floor, (int i, int j) celling)
        {
            if (found || celling.i < 0 || celling.j < 0 || floor.i < 0 || floor.j < 0
                 || celling.i >= m || celling.j >= n || floor.i >= m || floor.j >= n
                ) return;
            if (map[floor.i][floor.j] > t || map[celling.i][celling.j] < t) return;

            var piviot = BinarySearchPiviot(floor, celling);
            if (piviot == null) return;
            (int i, int j) = piviot.Value;

            SearchArea((floor.i, j + 1), (i - 1, celling.j)); // search within top-left sub-matrix. 
            SearchArea((i + 1, floor.j), (celling.i, j - 1)); // search within bottom-right sub-matrix.
        }

        private (int i, int j)? BinarySearchPiviot((int i, int j) floor, (int i, int j) celling)
        {
            if (found) return null;

            int countOfRows = celling.i - floor.i + 1;
            int countOfColums = celling.j - floor.j + 1;

            if (countOfRows > countOfColums) return BinarySearchPiviotOnTheColumns(floor, celling);
            else return BinarySearchPiviotOnTheRows(floor, celling);
        }

        private (int i, int j)? BinarySearchPiviotOnTheRows((int i, int j) floor, (int i, int j) celling)
        {
            if (found) return null;

            int? locateStartRowInTheColumn = BinarySearchFirstBiggerInTheColumn(celling.j, floor.i, celling.i);
            if (!locateStartRowInTheColumn.HasValue) return null;
            int row = locateStartRowInTheColumn.Value;

            int? piviotRow = BinarySearchFirstBiggerInTheRow(row, floor.j, celling.j);
            if (!piviotRow.HasValue) return null;

            return (row, piviotRow.Value);
        }

        private (int i, int j)? BinarySearchPiviotOnTheColumns((int i, int j) floor, (int i, int j) celling)
        {
            if (found) return null;

            int? locateStartColumnInTheRow = BinarySearchFirstBiggerInTheRow(celling.i, floor.j, celling.j);
            if (!locateStartColumnInTheRow.HasValue) return null;

            int column = locateStartColumnInTheRow.Value;
            int? piviotColum = BinarySearchFirstBiggerInTheColumn(column, floor.i, celling.i);

            if (!piviotColum.HasValue) return null;
            return (piviotColum.Value, column);
        }

        private int? BinarySearchFirstBiggerInTheRow(int row, int start, int end)
        {
            int mid = start + (end - start) / 2;
            while (start <= end)
            {
                mid = (end + start) / 2;
                if (map[row][mid] >= t)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            if (map[row][start] == t) { found = true; return null; }
            return start;
        }

        private int? BinarySearchFirstBiggerInTheColumn(int column, int start, int end)
        {
            int mid = start + (end - start) / 2;
            while (start <= end)
            {
                mid = (end + start) / 2;
                if (map[mid][column] >= t)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            if (map[start][column] == t) { found = true; return null; }
            return start;
        }
    }
}
