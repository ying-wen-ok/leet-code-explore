using System;
using System.Collections.Generic;

namespace Heap
{
    public class KthSmallestElementinaSortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    pq.Enqueue(matrix[i][j], -matrix[i][j]);
                    if (pq.Count > k) pq.Dequeue();
                }
            return pq.Dequeue();
        }
    }
}
