using System;
using System.Collections.Generic;

namespace Heap
{
    public class WeightOfLastStone
    {
        public int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> weight = new PriorityQueue<int, int>();
            foreach (int i in stones) weight.Enqueue(-i, -i);

            while (weight.Count > 1)
            {
                int y = -weight.Dequeue();
                int x = -weight.Dequeue();

                if (x == y) continue;
                int newStone = y - x;
                weight.Enqueue(-newStone, -newStone);
            }
            return weight.Count == 0 ? 0 : - weight.Dequeue();
        }
    }
}
