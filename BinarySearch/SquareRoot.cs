using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class SquareRoot
    {
        /// <summary>
        /// Given a non-negative integer x, 
        /// return the square root of x rounded down to the nearest integer.
        /// The returned integer should be non-negative as well.
        /// </summary>

        public int MySqrt(int x)
        {
            long start = 1;
            long end = x;
            long i;
            while (start <= end)
            {
                i = (start + end) / 2;

                if (i * i > x) { end = i - 1; }
                else if (i * i < x) { start = i + 1; }
                else return (int)i;
            }
            return (int)end;
        }
    }
}
