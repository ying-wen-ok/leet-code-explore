using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindSmallestLetterGreaterThanTarget
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            int n = letters.Length;
            int start = 0;
            int end = n - 1;

            int i;
            while (start <= end)
            {
                i = (start + end) / 2;
                if (letters[i] > target) end = i - 1;
                else start = i + 1;
            }
            return start < n? letters[start] : letters[0];
        }
    }
}
