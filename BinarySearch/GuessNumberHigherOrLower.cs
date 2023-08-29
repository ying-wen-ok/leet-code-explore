using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class GuessNumberHigherOrLower
    {       
        public int GuessNumber(int n)
        {
            long start = 1;
            long end = n;
            long i;
            int g;

            while (start <= end)
            {
                i = (start + end) / 2;
                g = guess((int)i);

                if (g == 1) start = i + 1; // next guess need to decrease
                else if (g == -1) end = i - 1; // next guess  need to increase
                else return (int)i;
            }

            return (int)start;
        }

        // this function is not part of the solution
        public int guess(int num) 
        {           
            return -1; 
        }
    }
}
