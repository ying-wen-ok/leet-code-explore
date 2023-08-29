using System;
using System.Collections.Generic;

namespace Arrays
{
    public class FindNumberswithEvenNumberofDigits
    {
        public int FindNumbers(int[] nums)
        {
            int count = 0;
            foreach (int num in nums)
            {
                if(CountDigit(num) % 2 == 0) count++;
            }
            return count;
        }

        private int CountDigit(int num)
        {
            string s = num.ToString();
            return s.Length;
        }
    }
}
