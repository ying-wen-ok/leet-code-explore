using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MaxConsecutiveOnes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxConsecutiveOnes = 0;
            int countOnes = 0;

            foreach(int i in nums)
            {
                if(i == 0)
                {
                    maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, countOnes);
                    countOnes = 0;
                }
                else
                {
                    countOnes++;
                }
            }
            
            return Math.Max(maxConsecutiveOnes, countOnes); ;
        }
    }
}
