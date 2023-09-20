using System;
using System.Collections.Generic;

namespace Heap
{
    public class TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            foreach(int i in nums)
            {
                countDict.TryAdd(i, 0);
                countDict[i]++;
            }

            PriorityQueue<int, int> frequencePriority = new PriorityQueue<int, int>();
            foreach(var i in countDict)
            {
                frequencePriority.Enqueue(i.Key, i.Value);
                if (frequencePriority.Count > k) frequencePriority.Dequeue();
            }

            int[] topKFrequentNumber = new int[k];
            int j = 0;
            while(frequencePriority.Count > 0)
            {
                topKFrequentNumber[j] = frequencePriority.Dequeue();
                j++;
            }
            return topKFrequentNumber;
        }
    }
}
