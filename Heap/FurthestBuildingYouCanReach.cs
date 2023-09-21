using System;
using System.Collections.Generic;

namespace Heap
{
    public class FurthestBuildingYouCanReach
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int n = heights.Length;
            PriorityQueue<int, int> heightGaps = new PriorityQueue<int, int>();
            
            int totalBricksUsed = 0;            
            for (int i = 1; i < n; i++)
            {
                int gap = heights[i] - heights[i - 1];
                if (gap <= 0) continue;           

                heightGaps.Enqueue(gap, gap);
                if (heightGaps.Count > ladders)
                {
                    totalBricksUsed += heightGaps.Dequeue();
                    if (totalBricksUsed > bricks) return i - 1;
                }
            }
            return n - 1;
        }
    
    }
}
