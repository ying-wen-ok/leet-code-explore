using System;
using System.Collections.Generic;

namespace Heap
{
    public class KthLargest
    {
        PriorityQueue<int, int> data;
        int maxLength;
        public KthLargest(int k, int[] nums)
        {
            maxLength = k;
            data = new PriorityQueue<int, int>();
            foreach (int i in nums)
            {
                Add(i);
            }
        }

        public int Add(int val)
        {
            data.Enqueue(val, val);
            if (data.Count > maxLength) data.Dequeue();
            return data.Peek();
        }
    }
}
