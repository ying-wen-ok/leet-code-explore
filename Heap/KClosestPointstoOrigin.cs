using System;
using System.Collections.Generic;

namespace Heap
{
    public class KClosestPointstoOrigin
    {
        public int[][] KClosest(int[][] points, int k)
        {
            PriorityQueue<int, int> distancePQ = new PriorityQueue<int, int>();
            int n = points.Length;
            for(int i = 0; i < n; i++)
            {
                int distance = points[i][0]* points[i][0] + points[i][1]* points[i][1];
                distancePQ.Enqueue(i, -distance);
                if (distancePQ.Count > k) distancePQ.Dequeue();
            }

            int[][] kPoints = new int[k][];
            int index = 0; 
            while(distancePQ.Count > 0)
            {
                kPoints[index] = points[distancePQ.Dequeue()];
                index++;
            }
            return kPoints;
         }
    }
}
