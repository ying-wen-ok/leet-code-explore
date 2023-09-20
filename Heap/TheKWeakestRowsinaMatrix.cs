using System;
using System.Collections.Generic;

namespace Heap
{
    public class TheKWeakestRowsinaMatrix
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            // value : rowIndex
            // priority : Strongness
            PriorityQueue<int, int> weeknessPriority = new PriorityQueue<int, int>();

            int n = mat.Length;
            int m = mat[0].Length;
            for (int i = 0; i < n; i++)
            {
                int sumOfTheRow = 0; // count soldiers
                for (int j = 0; j < m; j++)
                {
                    sumOfTheRow += mat[i][j];
                }
                int strongness = CalculateRowStrongness(i, sumOfTheRow);

                weeknessPriority.Enqueue(i, -strongness);
                if (weeknessPriority.Count > k) weeknessPriority.Dequeue();
            }
            int[] kWeakestRows = new int[k];
            int rowIndex = k - 1;
            while (weeknessPriority.Count > 0)
            {
                kWeakestRows[rowIndex] = weeknessPriority.Dequeue();
                rowIndex--;
            }
            return kWeakestRows;
        }

        private int CalculateRowStrongness(int rowIndex, int sumOfTheRow)
        {
            return sumOfTheRow * 1000 + rowIndex;
        }
    }
}
