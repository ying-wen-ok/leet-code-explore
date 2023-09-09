using System;
using System.Collections.Generic;

namespace HashTable
{
    public class ContainsDuplicates
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> setOfMet = new HashSet<int>();
            foreach(int i in nums)
            {
                if (setOfMet.Contains(i)) return true;
                else setOfMet.Add(i);
            }

            return false;
        }
    }
}
