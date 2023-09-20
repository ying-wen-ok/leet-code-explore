using System;
using System.Collections.Generic;

namespace Heap
{
    public class KthLargestElementinanArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> kLargest = new PriorityQueue<int, int>();
            int n = nums.Length;
            foreach (int i in nums)
            {
                kLargest.Enqueue(i, i);
                if (kLargest.Count > k) kLargest.Dequeue();
            }
            return kLargest.Peek();
        }
    }
}