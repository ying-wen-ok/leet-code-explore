using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindFirstBadVersion
    {
        public int FirstBadVersion(int n)
        {
            long start = 0;
            long end = n;

            while (start <= end)
            {
                long mid = (start + end) / 2;
                if (!IsBadVersion((int)mid))  start = mid + 1;
                else end = mid - 1;
            }

            return (int)start;
        }

        // this function is not part of the solution
        bool IsBadVersion(int version) { return false; }
    }
}
