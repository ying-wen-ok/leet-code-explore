using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {
            long originalNum = num;
            long start = 1;
            long end = num;
            long i;
            while (start <= end)
            {
                i = (start + end) / 2;
                long perfectSquare = i * i;
                if (perfectSquare == originalNum) return true;
                else if (perfectSquare > originalNum) end = i - 1;
                else if (perfectSquare < originalNum) start = i + 1;
            }
            return false;
        }

    }
}
