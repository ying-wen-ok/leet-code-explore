using System;
using System.Collections.Generic;

namespace HashTable
{
    public class JewelsAndStones
    {
        public int NumJewelsInStones(string jewels, string stones)
        {
            int countOfJewels = 0;
            HashSet<char> jewelSet = jewels.ToHashSet();
            foreach(char stone in stones)
            {
                if (jewelSet.Contains(stone)) { countOfJewels++; }
            }
            return countOfJewels;
        }
    }
}
