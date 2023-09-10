using System;
using System.Collections.Generic;

namespace HashTable
{
    public class TopKFrequentElements
    {
        // time: O(n*logK)
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                countDict.TryAdd(i, 0);
                countDict[i]++;
            }
                        
            PriorityQueue<int, int> topKCountNumber = new PriorityQueue<int, int>();
            foreach(var numberAndCount in countDict)
            {
                int count = numberAndCount.Value;
                int number = numberAndCount.Key;

                topKCountNumber.Enqueue(number, count);
                if (topKCountNumber.Count > k) topKCountNumber.Dequeue();
            }

            int[] result = new int[k];
            int x = k - 1;
            while(topKCountNumber.Count > 0)
            {
                int number = topKCountNumber.Dequeue();
                result[x] = number;
                x--;
            }
            return result.ToArray();
        }
    }
}
