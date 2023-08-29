using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class SearchInASortedArrayOfUnknownSize
    {
        public int Search(ArrayReader reader, int target)
        {
            int start = 0;
            int end = 9999;
            int i;
            int val;

            while (start <= end)
            {
                i = (start + end) / 2;
                val = reader.Get(i);
                if (val == target) { return i; }
                else if (val < target) { start = i + 1; }
                else if (val > target) { end = i - 1; }
            }
            return -1;
        }
    }

    public class ArrayReader
    {
        public int Get(int index) 
        {
            //... 
            return -1; 
        }
    }
}
