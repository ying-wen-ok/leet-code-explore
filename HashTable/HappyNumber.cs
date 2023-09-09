using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HappyNumber
    {
        public bool IsHappy(int n)
        {
            HashSet<int> notHappySet = new HashSet<int>();
            int happyValue = n;
            while (happyValue != 1)
            {
                if (notHappySet.Contains(happyValue)) return false;
                notHappySet.Add(happyValue);
                happyValue = CalculateHappyValue(happyValue);
            }

            return true;
        }

        private int CalculateHappyValue(int n)
        {
            int[] digits = new int[11];

            // digits[0] = n % 10;
            // digits[1] = (n % 100) /10;

            for (int i = 0; i <= 10; i++)
            {
                digits[i] = (n % ((int)Math.Pow(10, i + 1))) / (int)Math.Pow(10, i);
            }

            int sum = 0;
            foreach (int i in digits)
            {
                sum += i * i;
            }

            return sum;
        }
    }
}
