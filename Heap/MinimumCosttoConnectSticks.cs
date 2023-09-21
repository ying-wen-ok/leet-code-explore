using System;
using System.Collections.Generic;

namespace Heap
{
    public class MinimumCosttoConnectSticks
    {
        public int ConnectSticks(int[] sticks)
        {
            PriorityQueue<int, int> sticksLengthPq = new PriorityQueue<int, int>();
            foreach(int i in sticks) sticksLengthPq.Enqueue(i,i);
            int cost = 0;
            while(sticksLengthPq.Count > 1)
            {
                int stickI = sticksLengthPq.Dequeue();
                int stickJ = sticksLengthPq.Dequeue();
                int combined = stickI + stickJ;
                cost += combined;
                sticksLengthPq.Enqueue(combined, combined);
            }
            return cost;
        }
    }
}
