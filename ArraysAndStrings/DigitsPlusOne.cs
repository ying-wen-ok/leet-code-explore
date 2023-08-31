using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class DigitsPlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            int extra = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                extra += digits[i];

                digits[i] = extra % 10;
                extra = (extra / 10);
            }
            if (extra == 0) return digits;

            int[] result = new int[n + 1];
            result[0] = extra;
            for (int i = 1; i <= n; i++)
            {
                result[i] = digits[i - 1];
            }
            return result;
        }
    }
}
