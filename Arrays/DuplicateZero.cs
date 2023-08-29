using System;
using System.Collections.Generic;

namespace Arrays
{
    public class DuplicateZero
    {
        public void DuplicateZeros(int[] arr)
        {
            int n = arr.Length;
            int[] dups = arr.ToArray();
            int j = 0;
            int i = 0;

            while (i < n)
            {
                if (dups[j] == 0)
                {
                    arr[i] = 0;  
                    i++;
                    j++;

                    if (i == n) break;
                  
                    arr[i] = 0;
                    i++;
                }
                else
                {
                    arr[i] = dups[j];
                    i++;
                    j++;
                }
            }

        }
    }
}