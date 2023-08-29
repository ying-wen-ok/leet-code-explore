using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindtheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {
            int n = nums.Length;
            int start = 1;
            int end = n;
            int guess;
            while (start <= end)
            {
                guess = (start + end) / 2;

                int equalToGuess = 0;
                int smallerThanGuess = 0;

                for (int i = 0; i < n; i++)
                {
                    if (nums[i] < guess) { smallerThanGuess++; }
                    else if (nums[i] == guess) { equalToGuess++; }
                }

                if (equalToGuess > 1) return guess;

                if (smallerThanGuess > guess - 1) { end = guess - 1; }
                else { start = guess + 1; }
            }
            return -1;
        }
    }
}
