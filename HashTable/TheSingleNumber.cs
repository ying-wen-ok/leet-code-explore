using System;
using System.Collections.Generic;

namespace HashTable
{
    public class TheSingleNumber
    {
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            foreach(int i in nums)
            {
                countDict.TryAdd(i,0);
                countDict[i]++;
            }

            foreach(int key in countDict.Keys)
            {
                if (countDict[key] == 1) return key;
            }

            return -30001;
        }
    }
}
